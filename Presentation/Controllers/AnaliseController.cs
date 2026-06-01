using gs_mobile.Application.Interfaces;
using gs_mobile.Domain.Entities;
using gs_mobile.Domain.Enums;
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

                ExibirResultado(historico, planetaSemelhante, planeta);
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
            var tipoPlaneta = _view.LerTipoPlaneta();

            var temperatura = _view.LerTemperatura();
            var gravidade = _view.LerGravidade();
            var pressao = _view.LerPressao();
            var oxigenio = _view.LerOxigenio();

            var condicoes = new CondicoesFisicas(temperatura, gravidade);
            var atmosfera = new Atmosfera("Personalizada", pressao, oxigenio);
            var coordenadas = new Coordenadas(0, 0);

            if (tipoPlaneta == 1)
            {
                return new PlanetaTerrestre(
                    nome,
                    condicoes,
                    atmosfera,
                    coordenadas
                );
            }
            else
            {
                return new PlanetaGasoso(
                    nome,
                    condicoes,
                    atmosfera,
                    coordenadas
                );
            }
        }

        private void ExibirResultado(HistoricoAnalise historico, Planeta planetaSemelhante, Planeta planeta)
        {
            string explicacao = GerarExplicacao(planeta);

            string resultado = $@"
=== RESULTADO DA ANÁLISE ===

Planeta: {historico.NomePlaneta}
Score de Habitabilidade: {historico.ScoreHabitabilidade}
Classificação: {historico.Classificacao}

Data da análise: {DateTimeHelper.FormatarDataPadrao(historico.DataAnalise)}

Planeta mais semelhante: {planetaSemelhante.Nome}

Motivo da análise:
{explicacao}

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

        private string GerarExplicacao(Planeta planeta)
        {
            var cond = planeta.CondicoesFisicas;
            var atm = planeta.Atmosfera;

            string mensagem = "";

            // Tipo
            if (planeta.Tipo == TipoPlaneta.Gasoso)
                mensagem += "- Planetas gasosos não são capazes de suportar vida.\n";
            else if (planeta.Tipo == TipoPlaneta.Terrestre)
                mensagem += "- Planetas com superfices terrestre são aptos para suportar vida.\n";

            // Temperatura
            if (cond.TemperaturaMedia > 50)
                mensagem += "- Temperatura extremamente alta, dificultando a sobrevivência.\n";
            else if (cond.TemperaturaMedia < 0)
                mensagem += "- Temperatura muito baixa, podendo causar congelamento.\n";
            else
                mensagem += "- Temperatura dentro de faixa aceitável para vida.\n";

            // Gravidade
            if (cond.Gravidade > 12)
                mensagem += "- Gravidade elevada, dificultando locomoção.\n";
            else if (cond.Gravidade < 5)
                mensagem += "- Gravidade baixa, podendo causar instabilidade física.\n";
            else
                mensagem += "- Gravidade adequada para seres humanos.\n";

            // Atmosfera
            if (!atm.PossuiOxigenio)
                mensagem += "- Ausência de oxigênio inviabiliza respiração humana.\n";
            else
                mensagem += "- Presença de oxigênio favorece a sobrevivência.\n";

            // Pressão
            if (atm.Pressao > 5)
                mensagem += "- Pressão atmosférica extremamente alta.\n";
            else if (atm.Pressao < 0.5)
                mensagem += "- Pressão atmosférica muito baixa.\n";
            else
                mensagem += "- Pressão atmosférica adequada.\n";

            return mensagem;
        }
    }
}
