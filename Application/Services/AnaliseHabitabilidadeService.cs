using gs_mobile.Application.Interfaces;
using gs_mobile.Domain.Entities;
using gs_mobile.Domain.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Application.Services
{
    public class AnaliseHabitabilidadeService : IAnaliseHabitabilidade
    {
        public HistoricoAnalise Analisar(Planeta planeta)
        {
            if (planeta == null)
                throw new ArgumentNullException(nameof(planeta));

            double score = planeta.CalcularScoreHabitabilidade();

            var classificacao = planeta.ClassificarHabitabilidade(score);

            var historico = new HistoricoAnalise(
                planeta.Nome,
                score,
                classificacao
            );

            return historico;
        }
    }
}
