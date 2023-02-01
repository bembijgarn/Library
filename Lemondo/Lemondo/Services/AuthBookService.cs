using Lemondo.Interface;
using LemondoDATA;
using LemondoDOMAIN;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Lemondo.Services
{
    public class AuthBookService : IAuthBookService
    {
        private readonly Lcontext _context;
        public AuthBookService (Lcontext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Author;
        }
        public IEnumerable<BOOKS> GetBooks()
        {
            return _context.BOOKS;
        }
    }
}
