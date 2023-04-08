using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mortaria.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
    public class AddCustomerModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AddCustomerModel> _logger;

        public AddCustomerModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AddCustomerModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("OnPostAsync called.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is not valid.");
                foreach (var modelState in ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        _logger.LogWarning($"Key: {modelState.Key}, Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Find the associated Business for the current user.
            var business = await _context.Businesses.SingleOrDefaultAsync(b => b.UserId == user.Id);

            if (business == null)
            {
                return NotFound($"Unable to load business for user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Set the BusinessId and UserId properties of the Customer.
            Customer.BusinessId = business.Id;
            Customer.UserId = user.Id;

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
                _logger.LogInformation("Customer added successfully.");

            return RedirectToPage("./CustomerList");
        }

    }
}
