using EmailService.Interfaces;
using EmailService.Model;
using Entities.Model;
using Entities.HelperMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages.LoginLogout {
    public class LoginTwoFactorAuthenticationModel : PageModel {
        private readonly UserManager<UserModel> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<UserModel> _signInManager;

        public LoginTwoFactorAuthenticationModel(UserManager<UserModel> userManager,
                                                 IEmailSender emailSender,
                                                 SignInManager<UserModel> signInManager) {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
        }
        [BindProperty]
        public UserTwoFactorAuthenticationModel TwoFactorModel { get; set; }
        public async Task<IActionResult> OnGet(string userName, bool rememberMe, string? returnUrl = null) {
            TwoFactorModel = new UserTwoFactorAuthenticationModel { RememberMe = rememberMe };

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null) {
                var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
                var message = new Message(new string[] { user.Email }, "Authentication Token", token);
                await _emailSender.SendEmailAsync(message);

                ViewData["ReturnUrl"] = returnUrl;
                return Page();

            }
            return RedirectToPage("Error");
        }
        public async Task<IActionResult> OnPost(string? returnUrl = null) {
            if (ModelState.IsValid) {
                var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
                if (user == null) {
                    return RedirectToPage("/Built-In/Error");
                }
                var result = await _signInManager.TwoFactorSignInAsync("Email", TwoFactorModel.TwoFactorCode,
                                                                       TwoFactorModel.RememberMe, true);
                if (result.Succeeded) {
                    return this.RedirectToLocal(returnUrl);
                }
            }
            ModelState.AddModelError("", "Invalid Login attempt");
            return Page();
        }
    }
}
