using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();



builder.Services.AddHttpClient();

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";  // Default login path"
    });



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

//Redirect the root path to the login page
app.MapGet("/", () => Results.Redirect("/Identity/Account/Login"));

// Make sure you're mapping Razor Pages
app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
