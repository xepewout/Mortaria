using Microsoft.AspNetCore.Mvc.RazorPages;
using Mortaria.Data;
using Mortaria.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
    public class ScheduleModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ScheduleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; set; }
        public IList<Appointment> Appointments { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
            Appointments = await _context.Appointments.ToListAsync();
        }
    }
}
