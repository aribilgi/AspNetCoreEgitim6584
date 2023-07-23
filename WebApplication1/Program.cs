using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication.Cookies; // uygulamada oturum açmayý etkinleþtirmek için.

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext i dependency injection ile kullanabilmek için burada servis olarak ekliyoruz yoksa hata veriyor.

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Admin/Login"; // giriþ yapmayan kullanýcýlarý giriþ için bu adrese yönlendir
                x.Cookie.Name = "AdminLogin"; // giriþ yapan kullanýcýlar için oluþacak cookie ismi bu olsun
            }); // uygulamada oturum açmayý etkinleþtirmek için.

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

            app.UseAuthentication(); // uygulamada oturum açmayý etkinleþtirmek için.
            app.UseAuthorization(); // Dikkat!!! .net core da kesinlikle önce app.UseAuthentication() sonra app.UseAuthorization() gelmeli yoksa oturum açýlamaz! Önce giriþ sonra yetkilendirme devreye girmeli!

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