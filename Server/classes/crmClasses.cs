//classes that program.cs uses
using System;

public class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string LastCall { get; set; }
    public string TimeZone { get; set;}
    public Dictionary<int, string> notes {get; set;}
}
public class Business
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    // other properties specific to the business
    public List<Customer> Customers { get; set; }
    // a list of customers associated with this business
}

