using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Domain.Structs
{
    public struct Coordenadas
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Coordenadas(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentException("Latitude deve estar entre -90 e 90.");

            if (longitude < -180 || longitude > 180)
                throw new ArgumentException("Longitude deve estar entre -180 e 180.");

            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Lat: {Latitude}, Long: {Longitude}";
        }
    }
}
