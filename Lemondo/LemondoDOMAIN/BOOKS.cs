using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondoDOMAIN
{
    public class BOOKS
    {
        public int Id { get; set; }
        public string Title { get;set; }
        public string Description { get; set; } 
        public string Picture { get;set;}
        public double Rating { get; set; }
        public int PublicationDate { get; set; }
        public bool Avaliable { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }  
    }
}
