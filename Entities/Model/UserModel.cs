using Microsoft.AspNetCore.Identity;

namespace Entities.Model {
    public class UserModel : IdentityUser {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
