using Microsoft.AspNetCore.Authorization;
using SignalR.DataAccsessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.
builder.Services.AddControllersWithViews();
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
var app = builder.Build();
//builder.Services.ConfigureApplicationCookie(opts => { opts.LoginPath = "/Login/Index"; });
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
