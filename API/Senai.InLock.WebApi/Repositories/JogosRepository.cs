using Domains;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string stringConexao = "Data Source=LAB08DESK2601\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ; integrated security=true;";

        public void Cadastrar(JogosDomain novoJogo)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, Valor , IdEstudio ) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor , @IdEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue( "@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);


                    con.Open();

                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> jogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT J.IdJogo, J.NomeJogo , J.Descricao , J.DataLancamento , J.Valor ,  E.NomeEstudio, J.IdEstudio FROM Jogos  J LEFT JOIN Estudios E on E.IdEstudio = J.IdEstudio";
                
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain Jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            NomeJogo = rdr[1].ToString(),
                            Descricao = rdr[2].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal (rdr["Valor"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Estudio =
                            {
                                NomeEstudio = rdr["NomeEstudio"].ToString(),
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])
                            }
                        };
                        jogos.Add(Jogo);
                    }
                }
            }
            return jogos;
        }
    }
}
