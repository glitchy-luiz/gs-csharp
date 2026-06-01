using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Presentation.Views
{
    public interface IConsoleView
    {
        string LerNomePlaneta();
        double LerTemperatura();
        double LerGravidade();
        double LerPressao();
        bool LerOxigenio();

        void ExibirResultado(string mensagem);
        void ExibirErro(string mensagem);
    }
}
