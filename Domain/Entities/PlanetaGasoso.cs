using gs_mobile.Domain.Enums;
using gs_mobile.Domain.Structs;
using gs_mobile.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.Entities
{
    public class PlanetaGasoso : Planeta
    {

        public PlanetaGasoso(
                    string nome,
                    CondicoesFisicas condicoesFisicas,
                    Atmosfera atmosfera,
                    Coordenadas localizacao) : base(nome, TipoPlaneta.Gasoso, condicoesFisicas, atmosfera, localizacao)
        {
        }

        public override double CalcularScoreHabitabilidade()
        {
            // Regra simples: planetas gasosos são inóspitos
            double score = 10;

            if (!Atmosfera.PossuiOxigenio)
                score -= 5;

            return score < 0 ? 0 : score;
        }

        public override ClassificacaoHabitabilidade ClassificarHabitabilidade(double score)
        {
            return ClassificacaoHabitabilidade.Inabitavel;
        }

    }
}
