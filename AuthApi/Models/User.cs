using Microsoft.AspNetCore.Identity;

namespace AuthApi.Models
{
    public class User : IdentityUser
    {
        public string CPF { get; set; }
    }
}
