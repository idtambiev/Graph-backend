using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Graph.API.Controllers.Base
{
    public class BaseController: ControllerBase
    {
        public string GetUserId()
        {
            var claim = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.UserData);
            string userId = claim.Value;
            return userId;
        }
    }
}
