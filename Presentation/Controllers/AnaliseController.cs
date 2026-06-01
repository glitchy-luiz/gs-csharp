using gs_mobile.Application.Interfaces;
using gs_mobile.Domain.Entities;
using gs_mobile.Domain.Historico;
using gs_mobile.Domain.Structs;
using gs_mobile.Domain.ValueObjects;
using gs_mobile.Infrastructure.Repositories;
using gs_mobile.Presentation.Views;
using gs_mobile.Shared.Exceptions;
using gs_mobile.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Presentation.Controllers
{
    public class AnaliseController
    {
        private readonly IConsoleView _view;
        private readonly IAnaliseHabitabilidade _analiseService;
        private readonly IComparadorPlanetario _comparadorService;
        private readonly PlanetaBaseRepository _repository;

        private readonly List<HistoricoAnalise> _historicos = new List<HistoricoAnalise>();

        public AnaliseController(
            IConsoleView view,
            IAnaliseHabitabilidade analiseService,
            IComparadorPlanetario comparadorService,
            PlanetaBaseRepository repository)
        {
            _view = view;
            _analiseService = analiseService;
            _comparadorService = comparadorService;
            _repository = repository;
        }


        public void Executar()
        {
            try
            {
                var planeta = CriarPlaneta();

                var historico = _analiseService.Analisar(planeta);
                _historicos.Add(historico);

                var planetaSemelhante = _comparadorService.CompararComBase(planeta);

                ExibirResultado(historico, planetaSemelhante);
            }
            catch (InputInvalidoException ex)
            {
                _view.ExibirErro(ex.Message);
            }
            catch (Exception)
            {
                _view.ExibirErro("Erro inesperado ao processar o planeta.");
            }
        }

        private Planeta CriarPlaneta()
        {
            var nome = _view.LerNomePlaneta();
            var temperatura = _view.LerTemperatura();
            var gravidade = _view.LerGravidade();
            var pressao = _view.LerPressao();
            var oxigenio = _view.LerOxigenio();

            var condicoes = new CondicoesFisicas(temperatura, gravidade);
            var atmosfera = new Atmosfera("Personalizada", pressao, oxigenio);
            var coordenadas = new Coordenadas(0, 0);

            return new PlanetaTerrestre(
                nome,
                condicoes,
                atmosfera,
                coordenadas
            );
        }

        private void ExibirResultado(HistoricoAnalise historico, Planeta planetaSemelhante)
        {
            string resultado = $@"
=== RESULTADO DA ANÁLISE ===

Planeta: {historico.NomePlaneta}
Score de Habitabilidade: {historico.ScoreHabitabilidade}
Classificação: {historico.Classificacao}

Data da análise: {DateTimeHelper.FormatarDataPadrao(historico.DataAnalise)}

Planeta mais semelhante: {planetaSemelhante.Nome}

Motivo da análise:
- Temperatura: {(historico.ScoreHabitabilidade < 50 ? "Fora do ideal" : "Adequada")}
- Condições gerais avaliadas com base em parâmetros terrestres

=================================
";

            _view.ExibirResultado(resultado);
        }

        public void ExibirHistorico()
        {
            if (!_historicos.Any())
            {
                _view.ExibirResultado("Nenhuma análise foi realizada ainda.");
                return;
            }

            _view.ExibirResultado("=== HISTÓRICO DE ANÁLISES ===");

            foreach (var historico in _historicos)
            {
                var texto = $@"
Planeta: {historico.NomePlaneta}
Score: {historico.ScoreHabitabilidade}
Classificação: {historico.Classificacao}
Data: {DateTimeHelper.FormatarDataPadrao(historico.DataAnalise)}
-----------------------------";

                _view.ExibirResultado(texto);
            }
        }

        public void ExibirPlanetasBase()
        {
            var planetas = _repository.ObterPlanetasBase();

            _view.ExibirResultado("=== PLANETAS BASE ===");

            foreach (var planeta in planetas)
            {
                var texto = $@"
Nome: {planeta.Nome}
Temperatura: {planeta.CondicoesFisicas.TemperaturaMedia} °C
Gravidade: {planeta.CondicoesFisicas.Gravidade}
Pressão: {planeta.Atmosfera.Pressao}
Possui Oxigênio: {(planeta.Atmosfera.PossuiOxigenio ? "Sim" : "Não")}
-----------------------------";

                _view.ExibirResultado(texto);
            }
        }

    }
}
