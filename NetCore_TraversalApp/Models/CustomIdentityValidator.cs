using Microsoft.AspNetCore.Identity;

namespace NetCore_TraversalApp.Models
{
    public class CustomIdentityValidator :IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { 
                Code= "PasswordTooShort",
                Description=$"Password should be minimum {length} character"
            };
        }
    }
}
