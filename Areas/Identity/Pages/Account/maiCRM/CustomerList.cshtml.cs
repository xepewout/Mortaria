using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mortaria.Data;

namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
    public class CustomerListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CustomerListModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<Customer> Customers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Customers = await _context.Customers
            .Where(c => c.UserId == user.Id)
           .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAddCustomerAsync(Customer newCustomer)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (ModelState.IsValid)
            {
                newCustomer.UserId = user.Id;
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();

                return RedirectToPage("./CustomerList");
            }

            // Reload the list of customers and display the form with validation errors.
            Customers = await _context.Customers
                .Where(c => c.UserId == user.Id)
                .ToListAsync();

            return Page();
        }

    }
    
}
