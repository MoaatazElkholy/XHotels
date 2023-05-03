using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using XHotels.Infrastructure;
using XHotels.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string connectionStringKey = "DefaultConnection";
var connectionString = builder.Configuration.GetConnectionString(connectionStringKey);
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    
    dbContext.Database.Migrate();
}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BookingWizard}/{action=Index}");

app.Run();