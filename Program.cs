var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Use this instead of AddRazorPages()
builder.Services.AddHttpClient<WeatherService>(); // Add this line to register WeatherService

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Change this line to map to HomeController and Index action

app.Run();
