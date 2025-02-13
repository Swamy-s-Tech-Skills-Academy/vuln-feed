using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services into the container

// Add support for MVC controllers and views
builder.Services.AddControllersWithViews();

// Uncomment the line below if you want to use Razor Pages too
// builder.Services.AddRazorPages();

// Register services from your Domain and Data projects
// For example:
// builder.Services.AddScoped<IVulnerabilityService, VulnerabilityService>();
// builder.Services.AddDbContext<VulnFeedDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // In production, use a centralized error handler and enable HSTS.
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map controller routes for both API and MVC.
// This maps the default route for MVC.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map attribute-routed API controllers.
app.MapControllers();

// Uncomment if you're using Razor Pages:
// app.MapRazorPages();

app.Run();
