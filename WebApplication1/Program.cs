using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // uygulamada oturum a�may� etkinle�tirmek i�in.

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext i dependency injection ile kullanabilmek i�in burada servis olarak ekliyoruz yoksa hata veriyor.

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Admin/Login"; // giri� yapmayan kullan�c�lar� giri� i�in bu adrese y�nlendir
                x.Cookie.Name = "AdminLogin"; // giri� yapan kullan�c�lar i�in olu�acak cookie ismi bu olsun
            }); // uygulamada oturum a�may� etkinle�tirmek i�in.

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

            app.UseRouting();

            app.UseAuthentication(); // uygulamada oturum a�may� etkinle�tirmek i�in.
            app.UseAuthorization(); // Dikkat!!! .net core da kesinlikle �nce app.UseAuthentication() sonra app.UseAuthorization() gelmeli yoksa oturum a��lamaz! �nce giri� sonra yetkilendirme devreye girmeli!

            app.MapControllerRoute(
                name: "admin",
                pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}