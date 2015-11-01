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
    class CargoRepositorio
    {
        public void AdicionarCargo(Cargo cargo)
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

        public void DeletarCargo(int id)
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
        }

        public void AtivarCargo(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (TransactionScope transacao = new TransactionScope())
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText =
                    "UPDATE Cargo SET Situacao = A WHERE IDCargo = @paramIDCargo";
                comando.AddParameter("paramIDCargo", id);
                connection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();
                connection.Close();
            }
        }

    }
}
