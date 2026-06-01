using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Application.DTOs
{
    public class PlanetaInputDto
    {
        public string Nome { get; set; }
        public double Temperatura { get; set; }
        public double Gravidade { get; set; }
        public double Pressao { get; set; }
        public bool PossuiOxigenio { get; set; }

    }
}
