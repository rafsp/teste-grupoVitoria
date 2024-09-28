using HeatWise_Sprint_2.Net.Persistence;
using HeatWise_Sprint_2.Net.Interface;
using HeatWise_Sprint_2.Net.Repositorios;
using HeatWise_Sprint_2.Net.Persistence.Repositorio;
using Microsoft.EntityFrameworkCore;


namespace HeatWise_Sprint_2.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container(caixa) de injeção de dependencia
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<HeatWiseDbContext>(
                options =>
                {
                    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
                }
            );

            builder.Services.AddScoped<IPlanoRepositorio, PlanoRepositorio>();
            builder.Services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            builder.Services.AddScoped<ISiteRepositorio, SiteRepositorio>();
            builder.Services.AddScoped<IAnaliseRepositorio, AnaliseRepositorio>();

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
