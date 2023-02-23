using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "martin@imaginagroup.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "pepe@imaginagroup.com",
                Name = "User1",
                Password = "pepe"
            }
        };


        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        // POST: 
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var token = new UserTokens();
                var valid = Logins.Any(login => login.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if(valid)
                {
                    var user = Logins.FirstOrDefault(u => u.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials!!");
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Token Error", ex);
            }
        }

        // GET: 
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
