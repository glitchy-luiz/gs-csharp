using gs_mobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Application.Interfaces
{
    public interface IComparadorPlanetario
    {
        Planeta CompararComBase(Planeta planeta);
    }
}
