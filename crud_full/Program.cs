using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crud_full.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<crud_fullContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("crud_fullContext") ?? throw new InvalidOperationException("Connection string 'crud_fullContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
