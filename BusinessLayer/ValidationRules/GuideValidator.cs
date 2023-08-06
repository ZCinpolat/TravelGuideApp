using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be nill");
            RuleFor(x => x.TwitterURL).NotEmpty().WithMessage("TwitterURL must not be nill");
            RuleFor(x => x.InstagramURL).NotEmpty().WithMessage("InstagramURL must not be nill");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image must not be nill");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description must not be nill");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Description length should be minimum 50 character");
        }
    }
}
