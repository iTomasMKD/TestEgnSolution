using EgnApp.Models;
using FluentValidation;

namespace EgnApp.Validation
{
    public class EgnValidator : AbstractValidator<Egn>
    {
        public EgnValidator()
        {
            RuleFor(guid => guid.Id).NotEmpty();
            RuleFor(name => name.Name).NotEmpty();
            RuleFor(age => age.Age).NotEmpty();
            RuleFor(egn => egn.EgnNumber).Length(10).NotEmpty();
        }
    }
}
