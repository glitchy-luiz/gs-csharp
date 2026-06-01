using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.ValueObjects
{
    public class CondicoesFisicas
    {
        public double TemperaturaMedia { get; private set; }
        public double Gravidade { get; private set; }

        public CondicoesFisicas(double temperaturaMedia, double gravidade)
        {
            if (temperaturaMedia < -273.15)
                throw new ArgumentException("Temperatura não pode ser menor que o zero absoluto.");

            if (gravidade <= 0)
                throw new ArgumentException("Gravidade deve ser maior que zero.");

            TemperaturaMedia = temperaturaMedia;
            Gravidade = gravidade;
        }
    }
}
