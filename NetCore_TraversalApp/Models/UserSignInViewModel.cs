using System.ComponentModel.DataAnnotations;

namespace NetCore_TraversalApp.Models
{
    public class UserSignInViewModel
    {

        [Required(ErrorMessage="Please enter username!")]
        public string Username{ get; set; }

        [Required(ErrorMessage ="Please enter user password!")]
        public string Password{ get; set; }
    }
}
