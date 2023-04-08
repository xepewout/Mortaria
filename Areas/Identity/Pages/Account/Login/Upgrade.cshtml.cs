using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Mortaria.Areas.Identity.Pages.Account.Login
{
    public class UpgradeModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UpgradeModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostBuyBasicAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Replace the FreeUser role with the BasicUser role
            await _userManager.RemoveFromRoleAsync(user, "FreeUser");
            await _userManager.AddToRoleAsync(user, "BasicUser");

            // Sign in the user again to refresh their claims with the new role
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostBuyPremiumAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Replace the FreeUser or BasicUser role with the PremiumUser role
            await _userManager.RemoveFromRoleAsync(user, "FreeUser");
            await _userManager.RemoveFromRoleAsync(user, "BasicUser");
            await _userManager.AddToRoleAsync(user, "PremiumUser");

            // Sign in the user again to refresh their claims with the new role
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToPage("/Index");
        }
    }
}