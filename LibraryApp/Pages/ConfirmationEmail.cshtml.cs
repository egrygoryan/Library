using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages
{
    public class ConfirmationEmailModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;

        public ConfirmationEmailModel(UserManager<UserModel> userManager) {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet(string emailToken, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) {
                RedirectToPage("/Built-in/Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);
            return  result.Succeeded ? Page() : RedirectToPage("/Built-in/Error");
        }
    }
}
