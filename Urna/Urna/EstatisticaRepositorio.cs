using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class EstatisticaRepositorio
    {
        public IList<Estatistica> Estatisticas()
        {
            IList<Estatistica> estatisticas = new List<Estatistica>();
            Estatistica estatisticaEncontrada = new Estatistica();
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "select c.NomeCompleto, c.NomePopular, COUNT(1) as votos from Voto v inner join Candidato c on c.IDCandidato = v.IDCandidato group by v.IDCandidato, c.NomeCompleto, c.NomePopular";

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    estatisticaEncontrada.NomeCompleto = reader["NomeCompleto"].ToString();
                    estatisticaEncontrada.NomePopular = reader["NomePopular"].ToString();
                    estatisticaEncontrada.NumeroVotos = Convert.ToInt32(reader["votos"]);
                    estatisticas.Add(estatisticaEncontrada);
                }
            }
            return estatisticas;
        }
    }
}
