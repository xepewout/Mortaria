using Microsoft.AspNetCore.Identity;

namespace Mortaria.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string? UserId { get; set; }
        public Business? Business { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string BusinessPhone { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Direct { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string TimeZone { get; set; }
        public string Industry { get; set; }
        public decimal RevenueInMillions { get; set; }
        public string Priority { get; set; }
        public int CallCount { get; set; }
        public string RelationshipType { get; set; }
        public string QuickNote { get; set; }
        public string QualityNote { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
    }
    
}
