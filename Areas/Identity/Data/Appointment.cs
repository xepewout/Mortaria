using Microsoft.AspNetCore.Identity;

namespace Mortaria.Data{
    public class Appointment
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    //public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Description { get; set; }

    // Add any other relevant fields for the appointment

    // Navigation properties
    }
}

