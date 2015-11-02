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
    public class CargoRepositorio
    {
        public bool AdicionarCargo(Cargo cargo, bool iniciouEleicao)
        {
            bool podeCadastrar = PodeCadastrar(cargo);
            bool verificarNome = VerificarNomeNuloOuVazio(cargo);
            if (podeCadastrar && !iniciouEleicao)
            {
                if (verificarNome)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                    using (TransactionScope transacao = new TransactionScope())
                    using (IDbConnection connection = new SqlConnection(connectionString))
                    {
                        IDbCommand comando = connection.CreateCommand();
                        comando.CommandText =
                            "INSERT INTO Cargo (Nome, Situacao) values(@paramNome, @paramSituacao)";
                        comando.AddParameter("@paramNome", cargo.Nome);
                        comando.AddParameter("@paramSituacao", cargo.Situacao);
                        connection.Open();
                        comando.ExecuteNonQuery();
                        transacao.Complete();
                        connection.Close();
                    }
                }
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public bool DeletarCargo(int id, bool iniciouEleicao)
        {
            if (!iniciouEleicao)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "DELETE FROM Cargo WHERE IDCargo = @paramIDCargo";
                    comando.AddParameter("paramIDCargo", id);
                    connection.Open();
                    comando.ExecuteNonQuery();
                    transacao.Complete();
                    connection.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AtivarCargo(int id, bool iniciouEleicao)
        {
            if (!iniciouEleicao)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "UPDATE Cargo SET Situacao = 'A' WHERE IDCargo = @paramIDCargo";
                    comando.AddParameter("paramIDCargo", id);
                    connection.Open();
                    comando.ExecuteNonQuery();
                    transacao.Complete();
                    connection.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool InativarCargo(int id, bool iniciarEleicao)
        {
            if (!iniciarEleicao)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText =
                        "UPDATE Cargo SET Situacao = 'I' WHERE IDCargo = @paramIDCargo";
                    comando.AddParameter("paramIDCargo", id);
                    connection.Open();
                    comando.ExecuteNonQuery();
                    transacao.Complete();
                    connection.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        //fazer validacao de campo nulo ou em branco
        public bool PodeCadastrar(Cargo cargo)
        {
            int contador = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection connection = new SqlConnection(connectionString)){
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "SELECT count(1) as contador FROM Cargo WHERE Nome = @paramNome";
                comando.AddParameter("paramNome", cargo.Nome);
                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    contador = Convert.ToInt32(reader["contador"]);
                }
                connection.Close();
            }
            if(contador == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarNomeNuloOuVazio(Cargo cargo)
        {
            if(!string.IsNullOrEmpty(cargo.Nome) && !string.IsNullOrEmpty(cargo.Nome))
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
