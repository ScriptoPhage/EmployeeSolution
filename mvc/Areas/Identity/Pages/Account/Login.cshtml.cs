using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Policy;

namespace mvc.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        // Handle login via Web API (AJAX)
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Make HTTP request to the Web API to authenticate the user
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7007/api/account/login", new
                {
                    username = Input.Username,
                    password = Input.Password
                });

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("User logged in via Web API.");
                    return LocalRedirect(returnUrl);  // Successful login, redirect to the returnUrl
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();  // If something failed, redisplay the form
        }
    }
}
