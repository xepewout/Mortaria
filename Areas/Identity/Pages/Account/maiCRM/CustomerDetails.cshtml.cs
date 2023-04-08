using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mortaria.Data;

namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
    public class CustomerDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CustomerDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public bool IsEditMode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool isEditMode = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.Include(c => c.Appointments).FirstOrDefaultAsync(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }

            IsEditMode = isEditMode;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./CustomerDetails", new { id = Customer.Id });
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public void ToggleEditMode()
        {
            IsEditMode = !IsEditMode;
        }
    }
}
