using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages.Password
{
    [ValidateAntiForgeryToken]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<UserModel> _userManager;
        public ResetPasswordModel(UserManager<UserModel> userManager) {
            _userManager = userManager;
        }
        [BindProperty]
        public UserResetPasswordModel ResetPassword { get; set; }
        public void OnGet(string token, string email)
        {
            ResetPassword = new UserResetPasswordModel { Token = token, Email = email }; 
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(ResetPassword.Email);
                if (user != null) {
                    var resetPassResult = await _userManager.ResetPasswordAsync(user, ResetPassword.Token, ResetPassword.Password);
                    if (!resetPassResult.Succeeded) {
                        foreach (var error in resetPassResult.Errors) {
                            ModelState.TryAddModelError(error.Code, error.Description);
                            return Page();
                        }
                    }
                }
            }
            return RedirectToPage("/Password/ResetPasswordConfirmation");
        }
    }
}
