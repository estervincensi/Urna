using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Urna
{
    public class PartidoRepositorio
    {

        public bool CadastrarNovoPartido(Partido partido)
        {
            bool podeCadastrar = PodeSerCadastrado(partido);

            if (podeCadastrar)
            {

                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "INSERT INTO Partido (Nome, Slogan,Sigla) values (@paramNome, @paramSlogan,@paramSigla)";

                    comando.AddParameter("paramNome", partido.Nome);
                    comando.AddParameter("paramSlogan", partido.Slogan);
                    comando.AddParameter("paramSigla", partido.Sigla);

                    connection.Open();

                    comando.ExecuteNonQuery();


                    transacao.Complete();
                    connection.Close();
                }

                return true;  // se pode cadastrar ele cadastra e retorna verdadeiro pra dizer que deu certo
            }
            else
            {
                return false; // se não pode cadastrar porque ja existe no banco ele retorna false pra dizer que não deu certo
            }
            
        }


        public bool PodeSerCadastrado(Partido partido)
        {
            int contador = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT count(1) as contador FROM Partido WHERE Nome = @paramNome or Sigla = @paramSigla";

                comando.AddParameter("paramNome", partido.Nome);
                comando.AddParameter("paramSigla", partido.Sigla);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    contador = Convert.ToInt32(reader["contador"]);
                 
                    Console.WriteLine(contador);
                }

                connection.Close();
            }

            if(contador == 0 && (partido.Nome != "" && partido.Sigla != "" && partido.Slogan != "") && (partido.Nome != null && partido.Sigla != null && partido.Slogan != null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
