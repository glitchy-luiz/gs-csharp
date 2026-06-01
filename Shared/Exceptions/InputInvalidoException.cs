using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_mobile.Shared.Exceptions
{
    public class InputInvalidoException : Exception
    {
        public InputInvalidoException()
                    : base("Entrada inválida.") { }

        public InputInvalidoException(string mensagem)
            : base(mensagem) { }
    }
}
