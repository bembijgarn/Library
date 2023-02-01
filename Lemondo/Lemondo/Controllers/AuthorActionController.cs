using Lemondo.Interface;
using Lemondo.Models;
using Lemondo.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lemondo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorActionController : ControllerBase
    {
        private readonly IAuthorActions _AuthorActions;
        public AuthorActionController(IAuthorActions service)
        {
            _AuthorActions = service;
        }
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(AddAuthorModel authormodel)
        {
            var Validate = new AUthorActionServiceValidation().Validate(authormodel);
            if (!Validate.IsValid)
            {
                return BadRequest(Validate.Errors[0].ErrorMessage);
            }       
            var Author = _AuthorActions.AddAuthor(authormodel);
            if (Author != null)
            {
                return Ok(new
                {
                    Name = authormodel.Name,
                    Lastname = authormodel.LastName,
                    YearOfBirth = authormodel.BrithYear
                });
            }
            return BadRequest("Sorry,This Author Already Exist");
        }
        [HttpGet("FindAuthor/{AuthorName}")]
        public IActionResult FindAuthor(string AuthorName)
        {
            var Author = _AuthorActions.FindAuthor(AuthorName);
            if (Author != null)
            {
                return Ok(new
                {
                    Name = Author.Name,
                    LastName = Author.LastName,
                    YearOfBirth = Author.DateOfBirth
                });
            }
            return BadRequest($"Sorry,Here is not  Author Named - \"{AuthorName}\"");
        }
        [HttpPut("UpdateAuthor/{AuthorName}/{AuthorLastName}")]
        public IActionResult UpdateAuthor([FromBody]AddAuthorModel Authormodel,string AuthorName,string AuthorLastName)
        {
            var Validate = new AUthorActionServiceValidation().Validate(Authormodel);
            if (!Validate.IsValid)
            {
                return BadRequest(Validate.Errors[0].ErrorMessage);
            }
            var Author = _AuthorActions.UpdateAuthor(Authormodel,AuthorName,AuthorLastName);
            if (Author != null)
            {
                return Ok("Author Info successfully Updated" + new
                {
                    Name = Authormodel.Name,
                    LastName = Authormodel.LastName,
                    YearOfBirth = Authormodel.BrithYear
                });
            }
            return BadRequest($"Sorry,Here is not  Author  - \"{AuthorName} {AuthorLastName}\"");
        }
    }
}
