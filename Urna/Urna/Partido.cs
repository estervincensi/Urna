using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Partido
    {
        public int IDPartido { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Slogan { get; set; }

        public Partido(int id,string nome,string sigla,string slogan)
        {
            this.IDPartido = id;
            this.Nome = nome;
            this.Sigla = sigla;
            this.Slogan = slogan;
        }

    }
}
