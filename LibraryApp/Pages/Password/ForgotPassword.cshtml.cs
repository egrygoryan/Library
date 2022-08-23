using EmailService.Interfaces;
using EmailService.Model;
using Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages.Password {
    [ValidateAntiForgeryToken]
    public class ForgotPasswordModel : PageModel {
        private readonly UserManager<UserModel> _userManager;
        private readonly IEmailSender _emailSender;
        public ForgotPasswordModel(UserManager<UserModel> userManager, IEmailSender emailSender) {
            _userManager = userManager;
            _emailSender = emailSender;
        }
        [BindProperty]
        public UserForgotPasswordModel ForgotPassword { get; set; }
        public void OnGet() {
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                return Page();
            }
            var user = await _userManager.FindByEmailAsync(ForgotPassword.Email);
            if (user != null) {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callback = Url.Page("/Password/ResetPassword", "OnGet", new { token, email = user.Email }, Request.Scheme);

                var message = new Message(new string[] { user.Email }, "Reset password token", callback);
                await _emailSender.SendEmailAsync(message);
            }
            
            return RedirectToPage("/Password/ForgotPasswordConfirmation");
        }
    }
}
