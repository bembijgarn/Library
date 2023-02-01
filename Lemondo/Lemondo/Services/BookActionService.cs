using Lemondo.Interface;
using LemondoDATA;
using LemondoDOMAIN;
using System.Linq;

namespace Lemondo.Services
{
    public class BookActionService : IBookActions
    {
        private readonly Lcontext _context;
        public BookActionService(Lcontext context)
        {
            _context = context;
        }
        public BOOKS TakeBook(string BookName)
        {
            var Book = _context.BOOKS.Where(x => x.Avaliable != false && x.Title.ToUpper() == BookName.ToUpper()).SingleOrDefault();
            if (Book != null)
            {
                Book.Avaliable = false;
                _context.BOOKS.Update(Book);
                _context.SaveChanges();
                return Book;
            }
            return null;
        }
        public BOOKS ReturnBook(string BookName)
        {
            var Book = _context.BOOKS.Where(x => x.Title == BookName && x.Avaliable != true).SingleOrDefault();
            if (Book != null)
            {
                Book.Avaliable = true;
                _context.BOOKS.Update(Book);
                _context.SaveChanges();
                return Book;
            }
            return null;
        }
        public BOOKS FindBook(string BookName)
        {
            
            var Book = _context.BOOKS.Where(x => x.Title.ToUpper() == BookName.ToUpper()).FirstOrDefault();
            var AuthorName = _context.Author.Where(x => x.Id == Book.AuthorId).FirstOrDefault();
            if (Book != null)
            {
               
                return Book;
            }
            return null;
        }
    }
}
