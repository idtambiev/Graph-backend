using BCrypt.Net;
using Graph.Common.Models;
using Graph.Data.Entities;
using Graph.DataAccess.Interfaces;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services
{
    public class AuthService: BaseService, IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IRepository repo, IConfiguration configuration)
            :base(repo)
        {
            _configuration = configuration;
        }

        public async Task<bool> Registration(RegistrationModel model)
        {
            try
            {
                var existedUser = await _repo.Context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (existedUser != null)
                {
                    return false;
                }
                User newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    
                };

                await _repo.Context.Users.AddAsync(newUser);
                await _repo.Context.SaveChangesAsync();

                return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tokens> Login(LoginModel model)
        {
            try
            {
                var existedUser = await _repo.Context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (existedUser == null)
                {
                    throw new Exception("User does not exist");
                }

                bool verified = BCrypt.Net.BCrypt.Verify(model.Password, existedUser.PasswordHash);

                if (!verified)
                {
                    throw new Exception("Incorrect email or password");
                }
                var tokens = await GenerateToken(existedUser);
                return tokens;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Tokens> GenerateToken(User user)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Email, user.Email),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { 
                    AccessToken = tokenHandler.WriteToken(token),
                    RefreshToken = tokenHandler.WriteToken(token),
                };

            } catch (Exception ex)
            {
                throw ex;
            }
        }


        //private PasswordHashModel GeneratePasswordHash(string password)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        var passwordSalt = hmac.Key;
        //        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //        return new PasswordHashModel
        //        {
        //            PasswordHash = passwordHash,
        //            PasswordSalt = passwordSalt
        //        };

        //    }
        //}

        //private bool VerifyPasswordHash(string password, PasswordHashModel model)
        //{
        //    using (var hmac = new HMACSHA512(model.PasswordSalt))
        //    {
        //        var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        return computeHash.SequenceEqual(model.PasswordHash);
        //    }
        //}
    }
}
