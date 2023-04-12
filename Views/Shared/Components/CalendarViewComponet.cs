using Microsoft.AspNetCore.Mvc;
using Mortaria.Data;
using Mortaria.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


public class CalendarViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    public CalendarViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();
        return View(appointments);
    }
}
