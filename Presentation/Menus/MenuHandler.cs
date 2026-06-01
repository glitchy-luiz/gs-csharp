using gs_mobile.Presentation.Controllers;
using gs_mobile.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Presentation.Menus
{
    public class MenuHandler
    {
        private readonly AnaliseController _controller;
        private readonly IConsoleView _view;

        public MenuHandler(AnaliseController controller, IConsoleView view)
        {
            _controller = controller;
            _view = view;
        }

        public void ExibirMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Criar planeta");
                Console.WriteLine("2 - Ver histórico");
                Console.WriteLine("3 - Ver planetas base");
                Console.WriteLine("0 - Sair");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _controller.Executar();
                        break;

                    case "2":
                        _controller.ExibirHistorico();
                        break;

                    case "3":
                        _controller.ExibirPlanetasBase();
                        break;

                    case "0":
                        Console.WriteLine("Encerrando...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
