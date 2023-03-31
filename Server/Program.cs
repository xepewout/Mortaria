using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;



class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;database=mortaria;uid=root;pwd=mh0U=r5Tt!";

        DatabaseOperations db = new DatabaseOperations(connectionString);
        int businessId = db.AddBusiness("Jorryn Corp.");
        Console.WriteLine(businessId);
        businessId = db.AddBusiness("Mortaria");
        Console.WriteLine(businessId);
        CreateHostBuilder(args).Build().Run();
    }
//creates instance of webserver to run
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    app.UseRouting();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync("Welcome to the CRM!");
                        });

                        endpoints.MapGet("/customers", async context =>
                        {
                            var customer = new Customer { Name = "John Smith", PhoneNumber = "555-1234" };
                            var json = JsonConvert.SerializeObject(customer.Name);

                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(json);
                        });
                        endpoints.MapGet("/business/{businessId}/login", async (context) =>
                        {
                            var businessId = context.Request.RouteValues["businessId"].ToString();
                            // get the business ID from the URL

                           var business = "jorryn";
                           //businesses.FirstOrDefault(b => b.Id == businessId);
                            // find the business with the given ID

                            if (business == null)
                            {
                                context.Response.StatusCode = 404;
                                await context.Response.WriteAsync("Business not found.");
                                return;
                            }

                            // render the login page for the business
                            await context.Response.WriteAsync($"<h1>Login to {business}</h1>");
                            // add login form here
                        });
                    });
                });
            });
}
