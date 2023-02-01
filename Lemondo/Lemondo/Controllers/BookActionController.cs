using Lemondo.Interface;
using LemondoDOMAIN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lemondo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookActionController : ControllerBase
    {
        private readonly IBookActions _Bookactions;

        public BookActionController(IBookActions service)
        {
            _Bookactions = service;
        }

        [HttpGet("TakeBook/{BookName}")]
        public IActionResult TakeBook(string BookName)
        {
            var book = _Bookactions.TakeBook(BookName);
            if (book != null)
            {
                return Ok("Request Completed , Your Book is Here:" + new
                {
                    Tittle = book.Title,
                    Description = book.Description,
                });
            }
            return BadRequest("Sorry,This Book is not Avaliable at this moment!");
        }
        [HttpPost("ReturnTheBook/{BookName}")]
        public IActionResult ReturnBook(string BookName)
        {
            var book = _Bookactions.ReturnBook(BookName);
            if (book != null)
            {
                return Ok("Thanks,Book successfully returned");
            }
            return BadRequest("Invalid Book");
        }
        [HttpGet("FindBook/{BookName}")]
        public IActionResult FindBook(string BookName)
        {
            var book = _Bookactions.FindBook(BookName);
            if (book != null)
            {
                return Ok(new
                {
                    BookName = book.Title,
                    Description = book.Description,
                    Picture = book.Picture,
                    Rating = book.Rating,
                    PublicDate = book.PublicationDate,                    
                }); 
            }
            return BadRequest($"Sorry,Here is not book named - {BookName}");
        }
    }
}
