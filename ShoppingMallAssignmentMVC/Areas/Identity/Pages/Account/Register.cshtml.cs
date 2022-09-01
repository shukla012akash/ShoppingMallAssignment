// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingMallAssignmentMVC.Areas.Identity.Data;
using ShoppingMallAssignmentMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace ShoppingMallAssignmentMVC.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ShoppingMallUser> _signInManager;
        private readonly UserManager<ShoppingMallUser> _userManager;
        private readonly IUserStore<ShoppingMallUser> _userStore;
        private readonly IUserEmailStore<ShoppingMallUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AdminDbContext _adminDbContext;

        public RegisterModel(
            RoleManager<IdentityRole> roleManager,
            UserManager<ShoppingMallUser> userManager,
            IUserStore<ShoppingMallUser> userStore,
            SignInManager<ShoppingMallUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AdminDbContext adminDbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _adminDbContext = adminDbContext;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public class InputModel
        {
            public string RoleName { get; set; }
            [Required]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must be 10 characters")]
            public string PanNumber { get; set; }   
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }   
            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public void MailSender()
        {

            SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential("akash.shukla@kellton.com", "kjtewbasuknuholl")
            };
            string subject = "Your Registration is Successfull";
            string body = $"Dear , Thanks for registering with us \n  \n Please login using https://localhost:7060/Identity/Account/Login";

            try
            {

                email.EnableSsl = true;
                email.Send("akash.shukla@kellton.com", $"{Input.Email}", subject, body);

            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }

        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var role = Input.RoleName;
            //var role = "Admin";
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.PanNumber = Input.PanNumber;
                try
                {
                    var data = new AdminModel() { Email = Input.Email, PanNumber = Input.PanNumber, RoleName = "Operator", Status = "Pending" };
                    var result1 = await _adminDbContext.AdminModels.AddAsync(data);
                    _adminDbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "X";
                }


                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                   
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, role);
                   

                   
                        //return RedirectToPage("Register Confirmation");


                    
                        //await _signInManager.SignInAsync(user, isPersistent: false);
                    MailSender();
                    return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ShoppingMallUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ShoppingMallUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ShoppingMallUser)}'. " +
                    $"Ensure that '{nameof(ShoppingMallUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ShoppingMallUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ShoppingMallUser>)_userStore;
        }
    }
}
