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
    public class CandidatoRepositorio
    {
        public bool Cadastrar(Candidato c)
        {
            if (PodeCadastrar(c) && !Eleicao.Iniciou)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "INSERT INTO Candidato(NomeCompleto,NomePopular,DataNascimento,RegistroTRE,IDPartido,Foto,Numero,IDCargo,Exibe) VALUES (@paramNomeCompleto,@paramNomePopular,@paramDataNascimento,@paramRegistroTRE,@paramIDPartido,@paramFoto,@paramNumero,@paramIDCargo,@paramExibe)";
                    comando.AddParameter("paramNomeCompleto", c.NomeCompleto);
                    comando.AddParameter("paramNomePopular", c.NomePopular);
                    comando.AddParameter("paramDataNascimento", c.DataNascimento);
                    comando.AddParameter("paramRegistroTRE", c.RegistroTRE);
                    comando.AddParameter("paramIDPartido", c.IDPartido);
                    comando.AddParameter("paramFoto", c.Foto);
                    comando.AddParameter("paramNumero",c.Numero);
                    comando.AddParameter("paramIDCargo", c.IDCargo);
                    comando.AddParameter("paramExibe", c.Exibe);

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
        public bool Editar(Candidato c)
        {
            if (PodeCadastrar(c) && !Eleicao.Iniciou)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "UPDATE Candidato SET NomeCompleto = @paramNomeCompleto,NomePopular = @paramNomePopular,DataNascimento = @paramDataNascimento,RegistroTRE = @paramRegistroTRE,IDPartido = @paramIDPartido,Foto = @paramFoto, Numero = @paramNumero,IDCargo = @paramIDCargo, Exibe = @paramExibe WHERE IDCandidato = @paramIDCandidato";
                    comando.AddParameter("paramIDCandidato", c.IDCandidato);
                    comando.AddParameter("paramNomeCompleto", c.NomeCompleto);
                    comando.AddParameter("paramNomePopular", c.NomePopular);
                    comando.AddParameter("paramDataNascimento", c.DataNascimento);
                    comando.AddParameter("paramRegistroTRE", c.RegistroTRE);
                    comando.AddParameter("paramIDPartido", c.IDPartido);
                    comando.AddParameter("paramFoto", c.Foto);
                    comando.AddParameter("paramNumero", c.Numero);
                    comando.AddParameter("paramIDCargo", c.IDCargo);
                    comando.AddParameter("paramExibe", c.Exibe);

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

        public bool ExcluirPorID(int IDCandidato)
        {
            if(PodeExcluir(IDCandidato) && !Eleicao.Iniciou)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
                using (TransactionScope transacao = new TransactionScope())
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();
                    comando.CommandText = "DELETE FROM Candidato where IDCandidato = @paramIDCandidato";
                    comando.AddParameter("paramIDCandidato",IDCandidato);

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

        private bool PodeExcluir(int idCandidato)
        {
            Candidato candidatoEncontrado = null;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                candidatoEncontrado = new Candidato();
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT * FROM Candidato WHERE IDCandidato = @paramIDCandidato";
                comando.AddParameter("paramIDCandidato",idCandidato);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    candidatoEncontrado.IDCandidato = Convert.ToInt32(reader["IDCandidato"]);
                    candidatoEncontrado.NomeCompleto = reader["NomeCompleto"].ToString();
                    candidatoEncontrado.NomePopular = reader["NomePopular"].ToString();
                    candidatoEncontrado.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                    candidatoEncontrado.RegistroTRE = reader["RegistroTRE"].ToString();
                    candidatoEncontrado.IDPartido = Convert.ToInt32(reader["IDPartido"]);
                    candidatoEncontrado.Foto = reader["Foto"].ToString();
                    candidatoEncontrado.Numero = Convert.ToInt32(reader["Numero"]);
                    candidatoEncontrado.IDCargo = Convert.ToInt32(reader["IDCargo"]);
                    candidatoEncontrado.Exibe = Convert.ToBoolean(reader["Exibe"]); 
                }
                connection.Close();
            }
            if (candidatoEncontrado != null && candidatoEncontrado.NomeCompleto != "Voto em Branco" && candidatoEncontrado.NomeCompleto != "Voto Nulo")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool PodeCadastrar(Candidato c)
        {
            bool TemPrefeitoDessePartido=false;
            if(c.IDCargo == 1){
                TemPrefeitoDessePartido = verificaPrefeitosDoPartido(c.IDPartido);
            }
            if (!string.IsNullOrEmpty(c.NomeCompleto) && !string.IsNullOrEmpty(c.NomePopular)&& CandidatoNaoExiste(c) && !TemPrefeitoDessePartido)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool verificaPrefeitosDoPartido(int partido)
        {
            int contador = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT COUNT(1) as contador FROM Candidato WHERE IDPartido = @paramIDPartido AND IDCargo = 1";
                comando.AddParameter("paramIDPartido",partido);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                if(reader.Read()){
                    contador = Convert.ToInt32(reader["contador"]);
                }
                connection.Close();
            }
            if(contador!=0){
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CandidatoNaoExiste(Candidato c)
        {
            Candidato candidatoEncontrado = null;
            string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                candidatoEncontrado = new Candidato();
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = "SELECT IDCandidato,NomeCompleto,NomePopular,DataNascimento,RegistroTRE,IDPartido,Foto,Numero,IDCargo,Exibe FROM Candidato WHERE NomePopular=@paramNomePopular or RegistroTRE = @paramRegistroTRE or Numero = @paramNumero";

                comando.AddParameter("paramNomePopular", c.NomePopular);
                comando.AddParameter("paramRegistroTRE",c.RegistroTRE);
                comando.AddParameter("paramNumero", c.Numero);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    candidatoEncontrado.IDCandidato =  Convert.ToInt32(reader["IDCandidato"]);
                    candidatoEncontrado.NomeCompleto = reader["NomeCompleto"].ToString();
                    candidatoEncontrado.NomePopular = reader["NomePopular"].ToString();
                    candidatoEncontrado.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                    candidatoEncontrado.RegistroTRE = reader["RegistroTRE"].ToString();
                    candidatoEncontrado.IDPartido = Convert.ToInt32(reader["IDPartido"]);
                    candidatoEncontrado.Foto = reader["Foto"].ToString();
                    candidatoEncontrado.Numero = Convert.ToInt32(reader["Numero"]);
                    candidatoEncontrado.IDCargo = Convert.ToInt32(reader["IDCargo"]);
                    candidatoEncontrado.Exibe = Convert.ToBoolean(reader["Exibe"]);
                }
                connection.Close();
                if (candidatoEncontrado.NomeCompleto==null)
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
}
