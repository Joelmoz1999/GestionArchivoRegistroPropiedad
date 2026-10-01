using GestionArchivoRegistroPropiedad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestionArchivoRegistroPropiedad
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<GestionArchivoRegistroPropiedadContext>(options =>
                        options.UseSqlServer(connectionString));

                    // Registrar los formularios
                    services.AddTransient<LoginForm>();
                    services.AddTransient<MenuPrincipalForm>();
                    // services.AddTransient<Form1>(); // Ya no lo usamos
                    services.AddTransient<GestionLibrosForm>();
                })
                .Build();

            ApplicationConfiguration.Initialize();

            // Iniciar con el Login
            var login = host.Services.GetRequiredService<LoginForm>();
            Application.Run(login);
        }
    }
}