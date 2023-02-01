using Lemondo.Helper;
using Lemondo.Interface;
using Lemondo.Models;
using Lemondo.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lemondo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRegistrationController : ControllerBase
    {
        private readonly ILoginRegistration _LoginRegistrationService;
        private readonly AppSettings _appSettings;
        public LoginRegistrationController(ILoginRegistration service, IOptions<AppSettings> appSettings)
        {
            _LoginRegistrationService = service;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("Registration")]
        public IActionResult Registration([FromBody]RegistrationModel user)
        {
            var Validate = new RegistrationValidation().Validate(user);
            if (!Validate.IsValid)
            {
                return BadRequest(Validate.Errors[0].ErrorMessage);
            }
            var Dbuser = _LoginRegistrationService.Registration(user);
            if (Dbuser != null)
            {
                return Ok("Registration Completed");
            }
            return BadRequest("Sorry,UserName or Email Already Exist");
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            var Validate = new LoginValidation().Validate(user);
            if (!Validate.IsValid)
            {
                return BadRequest(Validate.Errors[0].ErrorMessage);
            }
            var Dbuser = _LoginRegistrationService.Login(user);
            if (Dbuser != null)
            {
                string token = new JWTgenerator(_appSettings).GenerateToken(Dbuser);
                return Ok(new
                {
                    Username = Dbuser.UserName,
                    Token = token
                });
            }
            return BadRequest("Sorry,Username or Password is incorrect");
        }
    }
}
