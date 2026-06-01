using gs_mobile.Application.Interfaces;
using gs_mobile.Application.Services;
using gs_mobile.Infrastructure.Repositories;
using gs_mobile.Presentation.Controllers;
using gs_mobile.Presentation.Menus;
using gs_mobile.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IConsoleView, ConsoleView>();
                    services.AddScoped<IAnaliseHabitabilidade, AnaliseHabitabilidadeService>();
                    services.AddScoped<IComparadorPlanetario, ComparadorPlanetarioService>();
                    services.AddSingleton<PlanetaBaseRepository>();
                    services.AddScoped<AnaliseController>();
                    services.AddScoped<MenuHandler>();
                });

            var app = builder.Build();

            var controller = app.Services.GetRequiredService<AnaliseController>();

            var menu = app.Services.GetRequiredService<MenuHandler>();
            menu.ExibirMenu();
        }
    }
}
