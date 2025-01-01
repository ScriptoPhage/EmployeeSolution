using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mvc.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(ILogger<LogoutModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // Call Web API to log out the user
            var client = new HttpClient();
            var response = await client.PostAsync("https://localhost:7007/api/account/logout", null);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("User logged out via Web API.");

                // After successful logout, redirect to the return URL or home page
                return returnUrl != null ? LocalRedirect(returnUrl) : RedirectToPage();
            }
            else
            {
                _logger.LogWarning("Failed to log out via Web API.");

                // Redirect to the home page if log out fails
                return RedirectToPage();
            }
        }
    }
}
