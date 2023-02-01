using FluentValidation;
using Lemondo.Models;

namespace Lemondo.Validations
{
    public class LoginValidation : AbstractValidator<LoginModel>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().Length(6,26);
            RuleFor(x => x.Password).NotEmpty().Length(6, 26);
            
        }
    }
}
