using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Cargo
    {
        public int IdCargo { get; private set; }
        public string Nome { get; private set; }
        public char Situacao { get; set; }

        public Cargo(int idCargo, string nome, char situacao) 
        {
            this.IdCargo = idCargo;
            this.Nome = nome;
            this.Situacao = situacao;
        }
    }
}
