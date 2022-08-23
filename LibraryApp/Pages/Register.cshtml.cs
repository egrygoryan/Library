using AutoMapper;
using EmailService.Interfaces;
using EmailService.Model;
using Entities.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserModel> _userManager;
        private readonly IEmailSender _emailSender;

        public RegisterModel(IMapper mapper,
                             UserManager<UserModel> userManager,
                             IEmailSender emailSender) {
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        [BindProperty]
        public UserRegistrationModel UserModel{ get; set; }
        public void OnGet() {
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                return RedirectToAction(nameof(RegisterModel));
            }
            var user = _mapper.Map<UserModel>(UserModel);
            var result = await _userManager.CreateAsync(user, UserModel.Password);
            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    ModelState.TryAddModelError(error.Code, error.Description);
                    
                }
                return Page();
            }
            var enableTwoFactor = await _userManager.SetTwoFactorEnabledAsync(user, true);

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Page("/ConfirmationEmail", "OnGet", new { emailToken, Email = user.Email }, Request.Scheme);

            var message = new Message(new string[] { user.Email }, "Confirmation Email", confirmationLink);
            await _emailSender.SendEmailAsync(message);

            await _userManager.AddToRoleAsync(user, RoleModel.User.ToString());

            return RedirectToPage("SuccessRegistration");
        }
    }
}
