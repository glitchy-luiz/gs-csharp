using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Presentation.Views
{
    public class ConsoleView : IConsoleView
    {
        public string LerNomePlaneta()
        {
            Console.Write("Nome do planeta: ");
            return Console.ReadLine();
        }

        public double LerTemperatura()
        {
            return LerDouble("Temperatura média (°C): ");
        }

        public double LerGravidade()
        {
            Console.Write("Gravidade: ");
            return double.Parse(Console.ReadLine());
        }

        public double LerPressao()
        {
            Console.Write("Pressão atmosférica: ");
            return double.Parse(Console.ReadLine());
        }

        public bool LerOxigenio()
        {
            while (true)
            {
                Console.Write("Possui oxigênio? (s/n): ");
                var input = Console.ReadLine().ToLower();

                if (input == "s") return true;
                if (input == "n") return false;

                Console.WriteLine("Resposta inválida. Digite 's' ou 'n'.");
            }
        }

        public void ExibirResultado(string mensagem)
        {
            Console.WriteLine("\n=== RESULTADO ===");
            Console.WriteLine(mensagem);
        }

        public void ExibirErro(string mensagem)
        {
            Console.WriteLine($"Erro: {mensagem}");
        }

        public double LerDouble(string mensagem)
        {
            double valor;
            bool valido;

            do
            {
                Console.Write(mensagem);
                valido = double.TryParse(Console.ReadLine(), out valor);

                if (!valido)
                    Console.WriteLine("Valor inválido. Tente novamente.");
            } while (!valido);

            return valor;
        }

    }
}
