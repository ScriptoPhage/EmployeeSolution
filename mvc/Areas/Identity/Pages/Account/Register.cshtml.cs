using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace mvc.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(ILogger<RegisterModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        // AJAX request: You can now handle the user registration entirely through the API
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Here, you'd make an HTTP request to the Web API to create the user
                // For example, using HttpClient to send the registration data
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7007/api/account/register", new
                {
                    username = Input.Username,
                    email = Input.Email,
                    password = Input.Password
                });

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("User created a new account via Web API.");
                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
