using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mortaria.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;



var builder = WebApplication.CreateBuilder(args);
 // Add this line to print the connection string to the console

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

    
//razor pages builder: builder.Services.AddRazorPages(options => options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "Register"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasSubscription", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new SubscriptionRequirement());
    });
});
builder.Services.AddSingleton<IAuthorizationHandler, SubscriptionHandler>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
