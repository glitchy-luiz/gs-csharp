using gs_mobile.Domain.Enums;
using gs_mobile.Domain.Interfaces;
using gs_mobile.Domain.Structs;
using gs_mobile.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.Entities
{
    public abstract class Planeta : ICalculavelHabitabilidade
    {
        public string Nome { get; protected set; }
        public TipoPlaneta Tipo { get; protected set; }

        public CondicoesFisicas CondicoesFisicas { get; protected set; }
        public Atmosfera Atmosfera { get; protected set; }

        public Coordenadas Localizacao { get; protected set; }

        protected Planeta(
            string nome,
            TipoPlaneta tipo,
            CondicoesFisicas condicoesFisicas,
            Atmosfera atmosfera,
            Coordenadas localizacao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do planeta não pode ser vazio.");

            Nome = nome;
            Tipo = tipo;
            CondicoesFisicas = condicoesFisicas;
            Atmosfera = atmosfera;
            Localizacao = localizacao;
        }

        // abstrato pra implementa diferente dependendo do planeta
        public abstract double CalcularScoreHabitabilidade();

        // base
        public virtual ClassificacaoHabitabilidade ClassificarHabitabilidade(double score)
        {
            if (score < 20)
                return ClassificacaoHabitabilidade.Inabitavel;

            if (score < 50)
                return ClassificacaoHabitabilidade.Baixa;

            if (score < 80)
                return ClassificacaoHabitabilidade.Moderada;

            return ClassificacaoHabitabilidade.Alta;
        }
    }
}
