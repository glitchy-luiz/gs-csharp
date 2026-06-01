using gs_mobile.Domain.Entities;
using gs_mobile.Domain.Structs;
using gs_mobile.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Infrastructure.Repositories
{
    public class PlanetaBaseRepository
    {
        public List<Planeta> ObterPlanetasBase()
        {
            return new List<Planeta>
            {
                new PlanetaTerrestre(
                    "Terra",
                    new CondicoesFisicas(15, 9.8),
                    new Atmosfera("Nitrogênio/Oxigênio", 1.0, true),
                    new Coordenadas(0, 0)
                ),
                new PlanetaTerrestre(
                    "Marte",
                    new CondicoesFisicas(-60, 3.7),
                    new Atmosfera("CO2", 0.006, false),
                    new Coordenadas(0, 0)
                ),
                new PlanetaTerrestre(
                    "Vênus",
                    new CondicoesFisicas(460, 8.87),
                    new Atmosfera("CO2", 92, false),
                    new Coordenadas(0, 0)
                ),
                new PlanetaGasoso(
                    "Júpiter",
                    new CondicoesFisicas(-110, 24.79),
                    new Atmosfera("Hidrogênio/Helio", 100, false),
                    new Coordenadas(0, 0)
                ),

                new PlanetaGasoso(
                    "Saturno",
                    new CondicoesFisicas(-140, 10.44),
                    new Atmosfera("Hidrogênio/Helio", 140, false),
                    new Coordenadas(0, 0)
                )

            };
        }
    }
}
