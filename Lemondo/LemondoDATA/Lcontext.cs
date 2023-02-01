using LemondoDOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondoDATA
{
    public class Lcontext : DbContext
    {
        public Lcontext(DbContextOptions<Lcontext> options) : base(options)
        {

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<BOOKS> BOOKS { get; set; }
        public DbSet<User> User { get; set; }
    }
}
