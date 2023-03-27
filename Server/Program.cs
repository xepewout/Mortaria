using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

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
                    });
                });
            });
}
