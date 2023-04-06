using Microsoft.AspNetCore.Identity;

// Your Customer class code
namespace Mortaria.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public string Name { get; set; }
        public DateTime? LastAppointment { get; set; }
        public DateTime? NextAppointment { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
    }

}
