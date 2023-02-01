using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondoDOMAIN
{
    public class Author
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public List<BOOKS> book { get; set; } = new List<BOOKS>();
    }
}
