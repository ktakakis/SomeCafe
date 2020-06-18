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
    public class GenerateRecoveryCodesModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<GenerateRecoveryCodesModel> _logger;

        public GenerateRecoveryCodesModel(
            UserManager<IdentityUser> userManager,
            ILogger<GenerateRecoveryCodesModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string[] RecoveryCodes { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            if (!isTwoFactorEnabled)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                throw new InvalidOperationException($"Δεν είναι δυνατή η δημιουργία κωδικών ανάκτησης για χρήστη με αναγνωριστικό '{userId}' επειδή δεν έχουν ενεργοποιημένο το 2FA.");
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

            var isTwoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!isTwoFactorEnabled)
            {
                throw new InvalidOperationException($"Δεν είναι δυνατή η δημιουργία κωδικών ανάκτησης για χρήστη με αναγνωριστικό '{userId}' καθώς δεν έχουν ενεργοποιημένο το 2FA.");
            }

            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            RecoveryCodes = recoveryCodes.ToArray();

            _logger.LogInformation("Ο χρήστης με αναγνωριστικό '{UserId}' δημιούργησε νέους κωδικούς ανάκτησης 2FA.", userId);
            StatusMessage = "Έχετε δημιουργήσει νέους κωδικούς ανάκτησης.";
            return RedirectToPage("./ShowRecoveryCodes");
        }
    }
}