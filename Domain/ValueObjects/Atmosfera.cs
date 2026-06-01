using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.ValueObjects
{
    public class Atmosfera
    {
        public string Composicao { get; private set; }
        public double Pressao { get; private set; }
        public bool PossuiOxigenio { get; private set; }

        public Atmosfera(string composicao, double pressao, bool possuiOxigenio)
        {
            if (string.IsNullOrWhiteSpace(composicao))
                throw new ArgumentException("Composição não pode ser vazia.");

            if (pressao < 0)
                throw new ArgumentException("Pressão não pode ser negativa.");

            Composicao = composicao;
            Pressao = pressao;
            PossuiOxigenio = possuiOxigenio;
        }
    }
}
