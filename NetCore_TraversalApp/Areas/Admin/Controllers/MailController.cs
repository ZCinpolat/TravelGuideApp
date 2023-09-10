using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NetCore_TraversalApp.Areas.Admin.Models;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Route("Admin/Mail")]
	[AllowAnonymous]
	public class MailController : Controller
	{


        [Route("Index")]
        public IActionResult Index()
		{
			return View();
		}

        [Route("Index")] 
        [HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
			MimeMessage message = new MimeMessage();

			MailboxAddress mailFrom = new MailboxAddress("MyTestApp", "*************");
			message.From.Add(mailFrom);
			MailboxAddress mailTo = new MailboxAddress("System User", mailRequest.Reciever);
			message.To.Add(mailTo);	

			BodyBuilder builder = new BodyBuilder();
			builder.TextBody = mailRequest.Content;

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("******************", "batxxcicrcfacvtm");
			message.Body = builder.ToMessageBody();
			smtpClient.Send(message);
			smtpClient.Disconnect(true);
			return View();
		}
	}
}
