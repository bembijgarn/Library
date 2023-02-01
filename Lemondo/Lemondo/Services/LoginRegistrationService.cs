using Lemondo.Helper;
using Lemondo.Interface;
using Lemondo.Models;
using LemondoDATA;
using LemondoDOMAIN;
using System.Data;
using System.Linq;

namespace Lemondo.Services
{
    public class LoginRegistrationService : ILoginRegistration
    {
        private readonly Lcontext _context;
        public LoginRegistrationService(Lcontext context)
        {
            _context = context;
        }

        public User Login(LoginModel UserLogin)
        {
            var user = _context.User.Where(x => x.UserName == UserLogin.UserName).FirstOrDefault();
            if (user is null || new PassworHashing().HashPass(UserLogin.Password) != user.Password)
            {
                return null;
            }
            return user;
        }
        public User Registration(RegistrationModel user)
        {

            var checkusernameAndEmail = _context.User.Where(x => x.Email == user.Email || x.UserName == user.UserName).FirstOrDefault();
            if (checkusernameAndEmail is null)
            {
                User Dbuser = new User();
                Dbuser.Name = user.FirstName;
                Dbuser.LastName = user.LastName;
                Dbuser.UserName = user.UserName;
                Dbuser.Password = new PassworHashing().HashPass(user.Password);
                Dbuser.Email = user.Email;

                _context.Add(Dbuser);
                _context.SaveChanges();
                return Dbuser;
            }
            return null;

        }
    }
}
