using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mondays.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly TwilioVerifyClient _client;
        public IndexModel(
            UserManager<IdentityUser> userManager,
            TwilioVerifyClient client,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _client = client;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Κωδικός Χώρας")]
            public int DialingCode { get; set; }

            [Phone]
            [Display(Name = "Αριθμός τηλεφώνου")]
            public string PhoneNumber { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var dialingCode = 30;
            Username = userName;

            Input = new InputModel
            {
                Email = email,
                DialingCode=dialingCode,
                PhoneNumber = phoneNumber
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            IsPhoneNumberConfirmed = await _userManager.IsPhoneNumberConfirmedAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Παρουσιάστηκε μη αναμενόμενο σφάλμα κατά τη ρύθμιση μηνυμάτων ηλεκτρονικού ταχυδρομείου για χρήστη με αναγνωριστικό '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Παρουσιάστηκε μη αναμενόμενο σφάλμα κατά τη ρύθμιση του αριθμού τηλεφώνου για χρήστη με αναγνωριστικό '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Το προφίλ σου ενημερώθηκε";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostSendVerificationSMSAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _client.StartVerification(Input.DialingCode, Input.PhoneNumber);
                if (result.Success)
                {
                    return RedirectToPage("/Account/ConfirmPhone", new { area = "Identity", Input.DialingCode, Input.PhoneNumber });
                }

                ModelState.AddModelError("", $"Παρουσιάστηκε σφάλμα κατά την αποστολή του κωδικού επαλήθευσης: {result.Message}");
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "Παρουσιάστηκε σφάλμα κατά την αποστολή του κωδικού επαλήθευσης. Ελέγξτε ότι ο αριθμός τηλεφώνου είναι σωστός και δοκιμάστε ξανά");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Δεν είναι δυνατή η φόρτωση του χρήστη με αναγνωριστικό '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);


            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Επιβεβαιώστε το email σας",
                $"Επιβεβαιώστε τον λογαριασμό σας <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>κάνοντας κλικ εδώ</a>.");

            StatusMessage = "Στάλθηκε email επαλήθευσης. Παρακαλούμε ελέγξτε το email σας.";
            return RedirectToPage();
        }
    }
}
