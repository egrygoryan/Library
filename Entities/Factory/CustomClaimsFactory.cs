using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Entities.Factory {
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<UserModel> {
        public CustomClaimsFactory(UserManager<UserModel> userManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor) {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserModel user) {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Age", user.Age.ToString()));

            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles) {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }

    }
}
