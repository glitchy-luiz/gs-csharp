using gs_mobile.Application.Interfaces;
using gs_mobile.Domain.Entities;
using gs_mobile.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Application.Services
{
    public class ComparadorPlanetarioService : IComparadorPlanetario
    {

        private readonly PlanetaBaseRepository _repository;

        public ComparadorPlanetarioService(PlanetaBaseRepository repository)
        {
            _repository = repository;
        }

        public Planeta CompararComBase(Planeta planeta)
        {
            var planetasBase = _repository.ObterPlanetasBase();

            var planetasFiltrados = planetasBase
                .Where(p => p.Tipo == planeta.Tipo)
                .ToList();

            Planeta maisProximo = null;
            double menorDiferenca = double.MaxValue;

            foreach (var basePlaneta in planetasFiltrados)
            {
                double diferenca =
                    Math.Abs(planeta.CondicoesFisicas.TemperaturaMedia - basePlaneta.CondicoesFisicas.TemperaturaMedia) +
                    Math.Abs(planeta.CondicoesFisicas.Gravidade - basePlaneta.CondicoesFisicas.Gravidade);

                if (diferenca < menorDiferenca)
                {
                    menorDiferenca = diferenca;
                    maisProximo = basePlaneta;
                }
            }

            return maisProximo;
        }


    }
}
