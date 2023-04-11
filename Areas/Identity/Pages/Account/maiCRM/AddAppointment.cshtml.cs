using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mortaria.Data;
using Mortaria.Models;

namespace Mortaria.Areas.Identity.Pages.Account.maiCRM
{
public class AddAppointmentModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public AddAppointmentModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Customer> Customers { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        public string Description { get; set; }
    }

    public async Task OnGetAsync()
    {
        Customers = await _context.Customers.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var appointment = new Appointment
        {
            CustomerId = Input.CustomerId,
            Date = Input.Date,
            Time = Input.Time,
            Description = Input.Description
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Schedule");
    }
}

}
