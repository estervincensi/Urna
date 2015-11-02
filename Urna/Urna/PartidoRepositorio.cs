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

        public bool CadastrarNovoPartido(Partido partido, bool iniciouEleicao)
        {

            if (!iniciouEleicao)
            {
                bool existeBoBanco = JaExisteNoBanco(partido);
                bool atendeAosRequisitos = AtendeAosRequisitos(partido);

                if (!existeBoBanco && atendeAosRequisitos)
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

                    return true;  // se atende aos requisitos ele cadastra e retorna verdadeiro pra dizer que deu certo
                }
                else
                {
                    return false; // se não pode cadastrar porque ja existe no banco ou não atende aos requisitos ele retorna false pra dizer que não deu certo
                }

            }
            else
            {
                return false;
            }

            
            
        }


        public bool AtendeAosRequisitos(Partido partido)
        {
            if ((partido.Nome != "" && partido.Sigla != "" && partido.Slogan != "") && (partido.Nome != null && partido.Sigla != null && partido.Slogan != null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool JaExisteNoBanco(Partido partido)
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
                 
                }

                connection.Close();
            }
            if(contador == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

            
        }


        public bool EditarPartido(Partido partido, bool iniciouEleicao)
        {

            if (!iniciouEleicao)
            {

                bool atendeAosRequisitos = AtendeAosRequisitos(partido);
                int? idPartido = partido.IDPartido;
                bool existeNoDB = JaExisteNoBanco(partido);

                if (atendeAosRequisitos && idPartido != null && !existeNoDB)
                {
                    bool idExisteNoBanco = IdExisteNoBanco(partido.IDPartido);

                    if (idExisteNoBanco)
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

                        using (TransactionScope transacao = new TransactionScope())
                        using (IDbConnection connection = new SqlConnection(connectionString))
                        {
                            IDbCommand comando = connection.CreateCommand();
                            comando.CommandText = "UPDATE Partido SET Nome = @paramNome, Sigla = @paramSigla, Slogan = @paramSlogan WHERE IDPartido = @paramIDPartido";

                            comando.AddParameter("paramNome", partido.Nome);
                            comando.AddParameter("paramSlogan", partido.Slogan);
                            comando.AddParameter("paramSigla", partido.Sigla);
                            comando.AddParameter("paramIDPartido", partido.IDPartido);

                            connection.Open();

                            comando.ExecuteNonQuery();

                            transacao.Complete();
                            connection.Close();
                        }

                        return true;  // se atende aos requisitos e o id existe na tabela é feito o update e retorna verdadeiro pra dizer que deu certo

                    }
                    else
                    {
                        return false; // se não atende aos requisitos ele retorna false pra dizer que não deu certo
                    }

                }
                else
                {
                    return false; // se não atende aos requisitos ele retorna false pra dizer que não deu certo
                }

            }
            else
            {
                return false;
            }
      
        }



        public bool IdExisteNoBanco(int idPartido)
        {
            int contador = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT count(1) as contador FROM Partido WHERE IDPartido = @paramIDPartido";

                comando.AddParameter("paramIDPartido", idPartido);

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
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool ExcluirPartido(int idPartido, bool iniciouEleicao)
        {
            if (!iniciouEleicao)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "DELETE FROM Partido WHERE IDPartido = @paramIDPartido";
                    comando.AddParameter("paramIDPartido", idPartido);


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
    }
}
