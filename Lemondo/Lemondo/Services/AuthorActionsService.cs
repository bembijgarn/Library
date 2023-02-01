using Lemondo.Interface;
using Lemondo.Models;
using LemondoDATA;
using LemondoDOMAIN;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lemondo.Services
{
    public class AuthorActionsService : IAuthorActions
    {
        private readonly Lcontext _context;
        public AuthorActionsService(Lcontext context)
        {
            _context = context;
        }

        public Author AddAuthor(AddAuthorModel authormodel)
        {
            var author = _context.Author;
            var checkauthorifalreadyexist = author.Where(x => x.Name == authormodel.Name && x.LastName == authormodel.LastName).FirstOrDefault();
            if (checkauthorifalreadyexist == null)
            {
                Author Dbauthor = new Author();
                Dbauthor.Name = authormodel.Name;
                Dbauthor.LastName = authormodel.LastName;
                Dbauthor.DateOfBirth = authormodel.BrithYear;

                _context.Add(Dbauthor);
                _context.SaveChanges();

                return Dbauthor;              
            }
            return null;
        }
        public Author FindAuthor(string AuthorName)
        {
            var author = _context.Author.Where(x => x.Name.ToUpper() == AuthorName.ToUpper()).FirstOrDefault();
            if (author != null)
            {
                return author;
            }
            return null;
        }
        public Author UpdateAuthor(AddAuthorModel authormodel,string AuthorName,string AuthorLastName)
        {
            var author = _context.Author.Where(x => x.Name.ToUpper() == AuthorName.ToUpper() && x.LastName.ToUpper() == AuthorLastName.ToUpper())
            .FirstOrDefault();
           

            if (author != null)
            {
                author.Name = authormodel.Name;
                author.LastName = authormodel.LastName;
                author.DateOfBirth = authormodel.BrithYear;
                _context.Author.Update(author);
                _context.SaveChanges();
                return author;
            }
            return null;
        }
    }
}
