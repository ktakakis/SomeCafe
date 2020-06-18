using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Mondays.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<IdentityUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Δεν είναι δυνατή η απενεργοποίηση του 2FA για χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}' καθώς δεν είναι ενεργοποιημένη αυτήν τη στιγμή.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"Παρουσιάστηκε μη αναμενόμενο σφάλμα κατά την απενεργοποίηση του 2FA για χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("Ο χρήστης με αναγνωριστικό '{ UserId}' απενεργοποίησε το 2fa.", _userManager.GetUserId(User));
            StatusMessage = "Το 2fa έχει απενεργοποιηθεί. Μπορείτε να ενεργοποιήσετε το 2fa όταν ρυθμίζετε μια εφαρμογή ελέγχου ταυτότητας";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}