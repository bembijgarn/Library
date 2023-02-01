using Lemondo.Models;
using LemondoDOMAIN;

namespace Lemondo.Interface
{
    public interface ILoginRegistration
    {
        User Login(LoginModel Userlogin);
        User Registration(RegistrationModel UserRegistration);
    }
}
