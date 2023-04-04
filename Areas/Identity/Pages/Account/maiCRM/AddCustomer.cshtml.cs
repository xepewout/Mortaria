using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mortaria.Models;
using Mortaria.Data;
namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
    public class AddCustomerModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AddCustomerModel(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public Customer NewCustomer { get; set; } = new Customer();

        public async Task<IActionResult> OnPostAsync()
        {
            //Console.WriteLine("1");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            //Console.WriteLine("2");
            Customer.UserId = user.Id;
           //Console.WriteLine(Customer.UserId);
            _context.Customers.Add(Customer);
            //Console.WriteLine(Customer);
            await _context.SaveChangesAsync();
            //Console.WriteLine(Customer);
            return RedirectToPage("./CustomerList");
        }
    }
}
