using Graph.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Registration(RegistrationModel model);
        Task<Tokens> Login(LoginModel model);
    }
}
