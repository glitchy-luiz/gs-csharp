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
            while (true)
            {
                Console.Write("Nome do planeta: ");
                var nome = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(nome))
                    return nome;

                Console.WriteLine("O nome não pode ser vazio.");
            }
        }

        public double LerTemperatura()
        {
            return LerDouble("Temperatura média (°C): ");
        }

        public double LerGravidade()
        {
            return LerDouble("Gravidade (m/s²): ");
        }

        public double LerPressao()
        {
            return LerDouble("Pressão atmosférica (atm): ");
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

        public int LerTipoPlaneta()
        {
            while (true)
            {
                Console.WriteLine("\nSelecione o tipo do planeta:");
                Console.WriteLine("1 - Terrestre");
                Console.WriteLine("2 - Gasoso");

                Console.Write("Opção: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int tipo) && (tipo == 1 || tipo == 2))
                    return tipo;

                Console.WriteLine("Opção inválida. Escolha 1 ou 2.");
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
            while (true)
            {
                Console.Write(mensagem);
                var input = Console.ReadLine();

                if (double.TryParse(input, out double valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Digite um número válido.");
            }
        }
    }
}
