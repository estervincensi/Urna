using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    class Eleitor
    {
        public int IDEleitor { get; set; }
        public string Nome { get; set; }
        public string TituloEleitoral { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string ZonaEleitoral { get; set; }
        public string Secao { get; set; }
        public char Situacao { get; set; }
        public char Votou { get; set; }

        public Eleitor(int idEleitor, string nome, string tituloEleitoral, string rg, string cpf, DateTime dataNascimento, string zonaEleitoral, string secao, char situacao, char votou)
        {
            this.IDEleitor = idEleitor;
            this.Nome = nome;
            this.TituloEleitoral = tituloEleitoral;
            this.RG = rg;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
            this.ZonaEleitoral = zonaEleitoral;
            this.Secao = secao;
            this.Situacao = situacao;
            this.Votou = votou;
        }
    }
}
