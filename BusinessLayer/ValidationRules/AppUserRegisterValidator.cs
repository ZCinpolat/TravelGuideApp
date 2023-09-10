using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator :AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Please enter Surname");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter Surname");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please enter email address");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Please enter phone");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter password");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Password length should be minimum 5 character");
            RuleFor(x => x.ConfirmPassword).MinimumLength(5).WithMessage("ConfirmPassword length should be minimum 5 character");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Please enter password ConfirmPassword");
            RuleFor(x => x.ConfirmPassword).NotEqual(x => x.Password).WithMessage("Parsswords did not match");
        }
       
    }
}
