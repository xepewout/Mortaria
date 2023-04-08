using Microsoft.AspNetCore.Identity;
namespace Mortaria.Data{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}