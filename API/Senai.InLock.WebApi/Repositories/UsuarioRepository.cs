using Domains;
using Senai.InLock.WebApi.Interfaces;

using Senai.InLock.WebApi.ViewModel;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringConexao = "Data Source=LAB08DESK2601\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ; integrated security=true;";

        public UsuariosDomain BuscarPorEmailSenha(LoginViewModel login)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string busca = $"SELECT U.IdUsuario, U.Email , U.Senha , U.IdTipoUsuario, T.Titulo FROM Usuarios U INNER JOIN" +
                    $" TipoUsuarios T ON U.IdTipoUsuario = T.IdTipoUsuario WHERE Email = '{login.Email}' AND Senha = '{login.Senha}'";

                using (SqlCommand cmd = new SqlCommand(busca, con))
                {
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            UsuariosDomain user = new UsuariosDomain
                            {
                                IdUsuario = Convert.ToInt32(rdr[0]),
                                Email = rdr[1].ToString(),
                                Senha = rdr[2].ToString(),
                                IdTipoUsuario = Convert.ToInt32(rdr[3]),
                                TipoUsuario =
                                {
                                    Titulo = rdr[4].ToString(),
                                    IdTipoUsuario = Convert.ToInt32(rdr[3])
                                }
                            };

                            return user;
                        }
                    }
                    return null;

                }
            }
        }

                public void Cadastrar(UsuariosDomain novoUsuario)
                {

                    using (SqlConnection con = new SqlConnection(stringConexao))
                    {

                        string queryInsert = "INSERT INTO Usuarios(Email, Senha, IdTipoUsuario) " +
                                             "VALUES (@Email, @Senha, @IdTipoUsuario)";


                        using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                        {

                            cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                            cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                            cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);


                            con.Open();


                            cmd.ExecuteNonQuery();

                        }
                    }
                }

                public List<UsuariosDomain> Listar()
                {
                    List<UsuariosDomain> usuarios = new List<UsuariosDomain>();


                    using (SqlConnection con = new SqlConnection(stringConexao))
                    {

                        string querySelectAll = "SELECT U.IdUsuario, U.Email , U.Senha , U.IdTipoUsuario, T.Titulo FROM Usuarios U INNER JOIN" +
                    " TipoUsuarios T ON U.IdTipoUsuario = T.IdTipoUsuario";


                        con.Open();


                        SqlDataReader rdr;


                        using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                        {


                            rdr = cmd.ExecuteReader();


                            while (rdr.Read())
                            {

                                UsuariosDomain usuario = new UsuariosDomain
                                {

                                    IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                                    Email = rdr["Email"].ToString(),
                                    Senha = rdr["Senha"].ToString(),
                                    IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                    TipoUsuario =
                                    {
                                        IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                        Titulo = rdr["Titulo"].ToString()

                                    }



                                };


                                usuarios.Add(usuario);
                            }
                        }
                    }

                    return usuarios;
                }
    }
}

