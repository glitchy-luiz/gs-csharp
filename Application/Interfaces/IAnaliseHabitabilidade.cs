using gs_mobile.Domain.Entities;
using gs_mobile.Domain.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Application.Interfaces
{
    public interface IAnaliseHabitabilidade
    {
        HistoricoAnalise Analisar(Planeta planeta);
    }
}
