using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mondays.Areas.Identity.Pages.Account
{
    [Authorize]
    public class ConfirmPhoneModel : PageModel
    {
        private readonly TwilioVerifyClient _client;
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmPhoneModel(TwilioVerifyClient client, UserManager<IdentityUser> userManager)
        {
            _client = client;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "������� �����")]
            public int DialingCode { get; set; }

            [Required]
            [Phone]
            [Display(Name = "������� ���������")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "������� �����������")]
            public string VerificationCode { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _client.CheckVerificationCode(Input.DialingCode, Input.PhoneNumber, Input.VerificationCode);
                if (result.Success)
                {
                    var identityUser = await _userManager.GetUserAsync(User);
                    identityUser.PhoneNumberConfirmed = true;
                    var updateResult = await _userManager.UpdateAsync(identityUser);

                    if (updateResult.Succeeded)
                    {
                        return RedirectToPage("ConfirmPhoneSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "������������� ������ ���� ��� ����������� ��� ������� �����������. ��������� ����");
                    }
                }
                else
                {
                    ModelState.AddModelError("", $"������������� ������ ���� ��� ����������� ��� ������� �����������: {result.Message}");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "������������� ������ ���� ��� ����������� ��� �������. ������� ��� � ������� ����������� ����� ������ ��� ��������� ����");
            }

            return Page();
        }
    }
}