using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages.LoginLogout
{
    public class LogoutModel : PageModel
    {
        private SignInManager<UserModel> _signInManager;

        public LogoutModel(SignInManager<UserModel> signInManager) {
            _signInManager = signInManager;
        }
        public  void OnGet() { }
        public async Task<IActionResult> OnPost() {
            await _signInManager.SignOutAsync();
            return RedirectToPage("../Index");
        }
    }
}
