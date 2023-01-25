using EasyChords.Core.Models.Identity;
using EasyChords.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EasyChordsDbContext>(options => options.UseSqlServer(connection));
builder.Services
    .AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EasyChordsDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<User, Role, EasyChordsDbContext, Guid>>()
    .AddRoleStore<RoleStore<Role, EasyChordsDbContext, Guid>>();
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
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
