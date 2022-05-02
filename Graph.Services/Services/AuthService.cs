using Graph.Common.Models;
using Graph.DataAccess.Interfaces;
using Graph.Services.Interfaces;
using Graph.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Services
{
    public class AuthService: BaseService, IAuthService
    {
        public AuthService(IRepository repo)
            :base(repo)
        {

        }

        private PasswordHashModel GeneratePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                var passwordSalt = hmac.Key;
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return new PasswordHashModel
                {
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

            }
        }

        private bool VerifyPasswordHash(string password, PasswordHashModel model)
        {
            using (var hmac = new HMACSHA512(model.PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(model.PasswordHash);
            }
        }
    }
}
