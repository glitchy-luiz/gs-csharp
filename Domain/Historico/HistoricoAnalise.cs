using gs_mobile.Domain.Enums;
using gs_mobile.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.Historico
{
    public class HistoricoAnalise
    {
        public string NomePlaneta { get; private set; }
        public double ScoreHabitabilidade { get; private set; }
        public ClassificacaoHabitabilidade Classificacao { get; private set; }
        public DateTime DataAnalise { get; private set; }

        public HistoricoAnalise(
            string nomePlaneta,
            double scoreHabitabilidade,
            ClassificacaoHabitabilidade classificacao)
        {
            if (string.IsNullOrWhiteSpace(nomePlaneta))
                throw new ArgumentException("Nome do planeta não pode ser vazio.");

            if (scoreHabitabilidade < 0)
                throw new ArgumentException("Score de habitabilidade não pode ser negativo.");

            NomePlaneta = nomePlaneta;
            ScoreHabitabilidade = scoreHabitabilidade;
            Classificacao = classificacao;
            DataAnalise = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{DateTimeHelper.FormatarDataPadrao(DataAnalise)} - {NomePlaneta} | Score: {ScoreHabitabilidade} | Classificação: {Classificacao}";
        }
    }
}
