using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class HeroValidators : AbstractValidator<HeroDto>
    {
        public HeroValidators() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.ImagePath)
                .Must(LinkMustBeAUri).WithMessage("{PropertyName} has incorrect URL format");

            RuleFor(x => x.DateOfDeath)
                .LessThan(DateTime.Now);
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
