using Lemondo.Models;
using LemondoDOMAIN;

namespace Lemondo.Interface
{
    public interface IAuthorActions
    {
        public Author AddAuthor(AddAuthorModel authormodel);
        public Author FindAuthor(string AuthorName);
        public Author UpdateAuthor(AddAuthorModel authormodel,string AuthorName,string AuthorLastName);
    }
}
