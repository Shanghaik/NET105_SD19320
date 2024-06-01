using CRUDWithAPI.IServices;
using CRUDWithAPI.Services;

namespace CRUDWithAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Khai báo DI (Dependency Injection) 
            builder.Services.AddTransient<IStudentServices, StudentServices>();
            // Transion (Ngắn nhất đỡ tốn tài nguyên nhất), Scope (Nhì - sống trong phạm vi resquest,
            // Singleton - dài nhất, sống từ khi được tạo ra đến hết vòng đời của project)
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
        }
    }
}