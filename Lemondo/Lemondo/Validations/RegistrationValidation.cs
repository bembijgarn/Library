using FluentValidation;
using Lemondo.Models;

namespace Lemondo.Validations
{
    public class RegistrationValidation : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(6, 26);
            RuleFor(x => x.LastName).NotEmpty().Length(6, 26);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserName).NotEmpty().Length(6, 26);
            RuleFor(x => x.Password).NotEmpty().Length(6, 26);
        }
    }
}
