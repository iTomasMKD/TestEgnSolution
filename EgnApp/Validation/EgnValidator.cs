using EgnApp.Contract;
using EgnApp.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EgnApp.Validation
{
    public class EgnValidator : AbstractValidator<Egn>
    {
        private readonly EgnContext _context;
        public EgnValidator(EgnContext context)
        {
            _context = context;
            RuleFor(guid => guid.Id).NotEmpty();
            RuleFor(name => name.Name).NotEmpty();
            RuleFor(age => age.Age).NotEmpty();
            RuleFor(egn => egn.EgnNumber).NotEmpty().Length(10, 10).Must(IsUnique).WithMessage("EGN must be unique");

        }
        private bool IsUnique(int egn)
        {
            var model = _context.Egn.GroupBy(x => x.EgnNumber)
               .Where(g => g.Count() > 1)
               .Select(y => y.Key)
               .ToList();  //judge whether parentclass has duplicate id
            if (model == null)
                return false;
            else return true;
        }
    }
}
