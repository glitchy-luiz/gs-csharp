using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Shared.Helpers
{
    public static class DateTimeHelper
    {
        public static string FormatarDataPadrao(DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm");
        }

        public static string FormatarDataCompleta(DateTime data)
        {
            return data.ToString("dddd, dd 'de' MMMM 'de' yyyy HH:mm");
        }
    }
}
