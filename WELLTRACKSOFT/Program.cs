using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WELLTRACKSOFT.Data;
using WELLTRACKSOFT.Models;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("WELLTRACKSOFTContextConnection") ?? throw new InvalidOperationException("Connection string 'WELLTRACKSOFTContextConnection' not found.");

//identity context
builder.Services.AddDbContext<WELLTRACKSOFTContext>(options => options.UseSqlServer(connectionString));

//base de datos context
builder.Services.AddDbContext<WellTrackDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WELLTRACKSOFTContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
