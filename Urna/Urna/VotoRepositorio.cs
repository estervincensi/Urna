using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Urna
{
    class VotoRepositorio
    {

        public bool Votar(string cpf, int idCandidato)
        {
            bool votou = VerificarSeJaVotou(cpf);
            bool candidatoExiste = CandidatoExisteNoBanco(idCandidato);

            if (!votou && candidatoExiste)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "INSERT INTO Voto (IDCandidato) values (@paramIDCandidato)";

                    comando.AddParameter("paramIDCandidato", idCandidato);

                    connection.Open();

                    comando.ExecuteNonQuery();


                    transacao.Complete();
                    connection.Close();

                }

                MudarColunaVotouParaSim(cpf);

                return true; // retorna verdadeiro se atende aos requisitos, então é feito o insert
            }
            else
            {
                return false; //retorna false se não atende aos requisitos,
            }


        }

        public bool VerificarSeJaVotou(string cpf)
        {
            string votou = "S";

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT Votou FROM Eleitor WHERE CPF = @paramCpf";

                comando.AddParameter("paramCpf", cpf);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    votou = reader["Votou"].ToString();

                }

                connection.Close();
            }
            if (votou == "N")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void MudarColunaVotouParaSim(string cpf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "UPDATE Eleitor SET Votou = 'S' WHERE CPF = @paramCpf";

                comando.AddParameter("paramCpf", cpf);

                connection.Open();

                comando.ExecuteNonQuery();

                transacao.Complete();
                connection.Close();
            }
        }


        public bool CandidatoExisteNoBanco(int idCandidato)
        {
            int contador = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT count(1) as contador FROM Candidato WHERE IDCandidato = @paramIDCandidato";

                comando.AddParameter("paramIDCandidato", idCandidato );

                connection.Open();

                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    contador = Convert.ToInt32(reader["contador"]);

                }

                connection.Close();
            }

            if (contador == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
