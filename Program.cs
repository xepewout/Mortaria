using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Mortaria.Authorization;
using Mortaria.Data;

var builder = WebApplication.CreateBuilder(args);
// Add this line to print the connection string to the console

// Add services to the container.
builder.Services.AddControllersWithViews();
//realtime complier (remove in production)
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();



//razor pages builder: builder.Services.AddRazorPages(options => options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "Register"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("HasSubscription", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new SubscriptionRequirement());
    });
});
builder.Services.AddSingleton<IAuthorizationHandler, SubscriptionHandler>();
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();
builder.Services.AddTransient<SeedData>();


var app = builder.Build();

using var scope = app.Services.CreateScope();
//var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
await SeedData.Initialize(scope.ServiceProvider);

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
