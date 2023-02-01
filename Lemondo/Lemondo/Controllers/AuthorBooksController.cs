using Lemondo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lemondo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBooksController : ControllerBase
    {
        private readonly IAuthBookService _authbookservice;
        public AuthorBooksController(IAuthBookService service)
        {
            _authbookservice = service;
        }


        [HttpGet("GetAuthors")]
        public IActionResult GetAuthors()
        {
            var Authors = _authbookservice.GetAuthors();
            if (Authors != null)
            {
                return Ok(Authors);
            }
            return BadRequest("Sorry,Here is not Authors");           
        }
        [HttpGet("GetBookss")]
        public IActionResult GetBooks()
        {
            var Books = _authbookservice.GetBooks();    
            if (Books != null)
            {
                return Ok(Books);
            }
            return BadRequest("Sorry,Here is not Books");
        }
    }
}
