using EntityLayer.Concrate;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description must not be nill");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Description length should be minimum 50 character");
            
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Image must not be nill");
        

        }
    }
}
