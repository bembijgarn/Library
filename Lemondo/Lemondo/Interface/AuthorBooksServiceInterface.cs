using LemondoDOMAIN;
using System.Collections.Generic;

namespace Lemondo.Interface
{
    public interface IAuthBookService
    {
       IEnumerable<Author> GetAuthors();
       IEnumerable<BOOKS> GetBooks();
    }
}
