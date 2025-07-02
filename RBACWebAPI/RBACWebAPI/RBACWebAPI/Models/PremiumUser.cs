using Microsoft.AspNetCore.Identity;

namespace RBACWebAPI.Models
{
    public class PremiumUser
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
