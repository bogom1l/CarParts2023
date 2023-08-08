// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

namespace CarParts.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty] public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData] public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email,
                    Input.Password,
                    true,
                    false);

                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


        public class InputModel
        {
            [Required] [EmailAddress] public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}