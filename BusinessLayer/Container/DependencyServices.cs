using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules.Announcements;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class DependencyServices
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDAL, EFCommentDAL>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDAL, EFAppUserDAL>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDAL, EFDestinationDAL>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDAL, EFReservationDAL>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDAL, EFGuideDAL>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PDFManager>();

            services.AddScoped<IContactUsMessageService, ContactUsManager>();
            services.AddScoped<IContactUsMessagesDAL, EFContactUsMessagesDAL>();

            services.AddScoped<IAnnouncementService, AnnouncmentManager>();
            services.AddScoped<IAnnouncementDAL, EFAnnouncementDAL>();
        }

        public static void AddCustomerValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTOs>, AnnouncementValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTOs>, AnnouncementUpdateValidator>();
        }
    }
}
