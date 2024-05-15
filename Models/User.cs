using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime RegisterDateTime { get; set; }
        public List<UserProduct>? UserProducts { get; set; }
        public List<Notification>? Notification { get; set; }
    }
}
