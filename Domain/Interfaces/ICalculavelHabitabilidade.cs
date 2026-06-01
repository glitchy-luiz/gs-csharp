using gs_mobile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.Interfaces
{
    public interface ICalculavelHabitabilidade
    {
        double CalcularScoreHabitabilidade();
        ClassificacaoHabitabilidade ClassificarHabitabilidade(double score);

    }
}
