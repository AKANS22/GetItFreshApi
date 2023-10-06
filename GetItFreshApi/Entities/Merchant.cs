using Microsoft.AspNetCore.Identity;

namespace GetItFreshApi.Entities
{
    public class Merchant : IdentityUser
    {
        public User User { get; set; }
        public string Profilepictureurl { get; set; }
        public string VideoUrl { get; set; }
        
    }
}
