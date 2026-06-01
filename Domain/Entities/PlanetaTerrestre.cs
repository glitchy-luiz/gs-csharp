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
    public class PlanetaTerrestre : Planeta
    {
        public PlanetaTerrestre(
                    string nome,
                    CondicoesFisicas condicoesFisicas,
                    Atmosfera atmosfera,
                    Coordenadas localizacao) : base(nome, TipoPlaneta.Terrestre, condicoesFisicas, atmosfera, localizacao)
        {
        }

        public override double CalcularScoreHabitabilidade()
        {
            double score = 100;

            var temp = CondicoesFisicas.TemperaturaMedia;
            if (temp < 0 || temp > 40)
                score -= 30;

            var gravidade = CondicoesFisicas.Gravidade;
            if (gravidade < 7 || gravidade > 12)
                score -= 20;

            if (!Atmosfera.PossuiOxigenio)
                score -= 40;

            if (Atmosfera.Pressao < 0.5 || Atmosfera.Pressao > 2)
                score -= 10;

            // score não negativo
            return score < 0 ? 0 : score;
        }

    }
}
