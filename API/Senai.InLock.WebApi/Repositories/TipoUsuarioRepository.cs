using Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private string stringConexao = "Data Source=LAB08DESK2601\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ; integrated security=true;";

        public List<TipoUsuariosDomain> Listar()
        {
            List<TipoUsuariosDomain> tipousuarios = new List<TipoUsuariosDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuarios";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {


                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        TipoUsuariosDomain tipousuario = new TipoUsuariosDomain
                        {

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])


                            ,
                            Titulo = rdr["Titulo"].ToString()



                        };


                        tipousuarios.Add(tipousuario);
                    }
                }
            }

            return tipousuarios;
        }
    }
}

