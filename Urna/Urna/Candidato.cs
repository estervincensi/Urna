using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Candidato
    {
        public int IDCandidato { get; set; }
        public string NomeCompleto { get; set; }
        public string NomePopular { get; set; }
        public DateTime DataNascimento { get; set; }
        public string RegistroTRE { get; set; }
        public int IDPartido { get; set; }
        public string Foto { get; set; }
        public int Numero { get; set; }
        public int IDCargo { get; set; }
        public bool Exibe { get; set; }
        
        public Candidato()
        {

        }

        public Candidato(string nomeCompleto, string nomePopular, DateTime dataNascimento,
            string registroTRE, int idPartido, string foto, int numero, int idCargo, bool exibe)
        {
            this.NomeCompleto = nomeCompleto;
            this.NomePopular = nomePopular;
            this.DataNascimento = dataNascimento;
            this.RegistroTRE = registroTRE;
            this.IDPartido = idPartido;
            this.Foto = foto;
            this.Numero = numero;
            this.IDCargo = idCargo;
            this.Exibe = exibe;
        }

    }
}
