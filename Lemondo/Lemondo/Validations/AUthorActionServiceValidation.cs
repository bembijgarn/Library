using FluentValidation;
using Lemondo.Models;

namespace Lemondo.Validations
{
    public class AUthorActionServiceValidation : AbstractValidator<AddAuthorModel>
    {
        public AUthorActionServiceValidation()
        {
            RuleFor(x => x.Name).NotEmpty().Length(6, 26);
            RuleFor(x => x.LastName).NotEmpty().Length(6, 26);
            RuleFor(x => x.BrithYear).NotEmpty();
        }
    }
}
