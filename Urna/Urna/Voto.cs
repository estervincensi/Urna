using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Voto
    {
        public int IDVoto { get; set; }
        public int IDCandidato { get; set; }

        public Voto(int idVoto, int idCandidato)
        {
            this.IDVoto = idVoto;
            this.IDCandidato = idCandidato;
        }
    }
    
}
