﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Mondays.Areas.Identity.Pages.Account.Manage
{
    public class ResetAuthenticatorModel : PageModel
    {
        UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        ILogger<ResetAuthenticatorModel> _logger;

        public ResetAuthenticatorModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ResetAuthenticatorModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            await _userManager.SetTwoFactorEnabledAsync(user, false);
            await _userManager.ResetAuthenticatorKeyAsync(user);
            _logger.LogInformation("Ο χρήστης με αναγνωριστικό '{UserId}' έχει επαναφέρει το κλειδί εφαρμογής ελέγχου ταυτότητας.", user.Id);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Το κλειδί της εφαρμογής ελέγχου ταυτότητας έχει επαναφερθεί, θα πρέπει να διαμορφώσετε την εφαρμογή ελέγχου ταυτότητας χρησιμοποιώντας το νέο κλειδί.";

            return RedirectToPage("./EnableAuthenticator");
        }
    }
}