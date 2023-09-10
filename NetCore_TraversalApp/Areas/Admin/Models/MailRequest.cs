namespace NetCore_TraversalApp.Areas.Admin.Models
{
	public class MailRequest
	{
        public string Name { get; set; }    
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
