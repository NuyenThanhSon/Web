using DoAnLTWeb.Models;
using DoAnLTWeb.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
    options.Cookie.Name = "HyperZCookie";
    options.LoginPath = "/User/Login";
});



builder.Services.AddDbContext<CsdlwebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddRazorPages();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, EFProductTypeRepository>();
builder.Services.AddScoped<ISupplierRepository, EFSupplierRepository>();
builder.Services.AddScoped<IWarehousedetailRepository, EFWarehousedetailRepository>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<ICustomerRepository, EFCustomerRepository>();
builder.Services.AddScoped<ICartRepository, EFCartRepository>();
builder.Services.AddScoped<IInvoiceRepository, EFInvoiceRepository>();
builder.Services.AddSession();
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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "gio-hang",
    pattern: "gio-hang",
    defaults: new { controller = "Cart", action = "Cart" });

    endpoints.MapControllerRoute(
  name: "them-gio-hang",
  pattern: "them-gio-hang",
  defaults: new { controller = "Cart", action = "AddtoCart" });

    endpoints.MapControllerRoute(
    name: "san-pham",
    pattern: "san-pham",
    defaults: new { controller = "Shop", action = "Index" });

    endpoints.MapControllerRoute(
     name: "chi-tiet-san-pham",
     pattern: "chi-tiet-san-pham/{productId?}",
     defaults: new { controller = "Shop", action = "Detailproduct" }
        );



    endpoints.MapControllerRoute(
    name: "hoan-thanh",
    pattern: "hoan-thanh",
    defaults: new { controller = "Cart", action = "Success" });

    endpoints.MapControllerRoute(
   name: "dang-xuat",
   pattern: "dang-xuat",
   defaults: new { controller = "User", action = "Logout" });

    endpoints.MapControllerRoute(
     name: "trang-chu",
     pattern: "trang-chu",
     defaults: new { controller = "Home", action = "Index" });

    endpoints.MapControllerRoute(
     name: "lien-he",
     pattern: "lien-he",
     defaults: new { controller = "Contact", action = "Index" });

    endpoints.MapControllerRoute(
  name: "thanh-toan",
  pattern: "thanh-toan",
  defaults: new { controller = "Cart", action = "Payment" });
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();