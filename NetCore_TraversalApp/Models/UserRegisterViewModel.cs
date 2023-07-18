using System.ComponentModel.DataAnnotations;

namespace NetCore_TraversalApp.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter email address")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Please enter phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password{ get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Compare("Password",ErrorMessage =" Password did not match, please check them again!")]
        public string ConfirmPassword { get; set; }

    }
}
