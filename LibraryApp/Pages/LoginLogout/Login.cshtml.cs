using Entities.Model;
using Entities.HelperMethods;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace LibraryApp.Pages.LoginLogout
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;
        public LoginModel(SignInManager<UserModel> signInManager) {
            _signInManager = signInManager;
        }

        [BindProperty]
        public UserLoginModel UserLogin { get; set; }
        public void OnGet(string? returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
        }
        public async Task<IActionResult> OnPost(string? returnUrl = null) {
            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(UserLogin.UserName, UserLogin.Password,
                    UserLogin.RememberMe, false);
                if (result.Succeeded) {
                    return this.RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor) {
                    return RedirectToPage("LoginTwoFactorAuthentication", "OnGet", new {UserLogin.UserName, 
                                          UserLogin.RememberMe, returnUrl });
                }
            }
            return Page();
        }
    }
}
