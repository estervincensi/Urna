using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Eleicao
    {
        public static bool Iniciou { get; private set; }

        public void IniciarEleicao()
        {
            Iniciou = true;
        }
        public void TerminarEleicao()
        {
            Iniciou = false;
        }
    }
}
