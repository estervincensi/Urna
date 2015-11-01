using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    class Grade
    {
        public int IDGrade { get; set; }
        public int IDCargo { get; set; }
        public char Situacao { get; set; }

        public Grade(int idGrade, int idCargo, char situacao)
        {
            this.IDGrade = idGrade;
            this.IDCargo = idCargo;
            this.Situacao = situacao;
        }
    }
}
