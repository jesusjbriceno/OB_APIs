using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly IStringLocalizer<AccountController> _stringLocalizer;

        // Example Users
        // TODO: Change by real users in DB
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


        public AccountController(UniversityDBContext context, JwtSettings jwtSettings, IStringLocalizer<AccountController> stringLocalizer)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _stringLocalizer = stringLocalizer;
        }

        // POST: 
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var token = new UserTokens();

                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName
                                 && user.Password == userLogin.Password
                                 select user).FirstOrDefault();

                Console.WriteLine($"User Found {searchUser}");

                //var isValid = _context.Users!.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase) && userLogin.Password.Equals(user.Password));
                //var valid = Logins.Any(login => login.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if(searchUser != null)
                {                    
                    token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Credentials!!");
                }

                return Ok(new
                {
                    Token = token.Token,
                    Message = _stringLocalizer["Welcome"].Value
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Get Token Error", ex);
            }
        }

        // GET: 
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        // POST:
        [HttpPost]
        public IActionResult Login(UserLogins userLogin)
        {
            UniversityApiBackend.Models.DataModels.User user = _context.Users!.First(u => u.Name == userLogin.UserName && u.Password == userLogin.Password);
            return (user == null) ? NotFound() : Ok(user);
        }
    }
}
