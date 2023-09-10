using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrate;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Announcements
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTOs>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is valid field");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Minimum title length is 5 chars.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Title max length is 50chars ");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is valid field");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Minimum Content length is 5 chars.");
            RuleFor(x => x.Content).MaximumLength(50).WithMessage("Content max length is 50chars ");
        }
    }
}
