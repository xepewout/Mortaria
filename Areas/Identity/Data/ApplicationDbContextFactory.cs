using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mortaria.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Read the configuration from the appsettings.json file
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create an instance of DbContextOptionsBuilder with the connection string
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            if (connectionString != null)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                // Handle the case when the connection string is null, e.g., throw an exception or use a default connection string
            }

            // Create and return a new ApplicationDbContext with the configured options
            return new ApplicationDbContext(optionsBuilder.Options);
        }

    }
}
