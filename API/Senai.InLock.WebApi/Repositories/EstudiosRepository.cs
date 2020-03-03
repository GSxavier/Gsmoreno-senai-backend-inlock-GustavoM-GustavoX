using Domains;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {

        private string stringConexao = "Data Source=LAB08DESK2601\\SQLEXPRESS; initial catalog=InLock_Games_Tarde ; integrated security=true;";

        


        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

               
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@NomeEstudio)";

                
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                  
                    cmd.Parameters.AddWithValue("@NomeEstudio", novoEstudio.NomeEstudio);
                    

                    
                    con.Open();

                   
                    cmd.ExecuteNonQuery();
                }
            }

        }

        

        

            public List<EstudiosDomain> Listar()
            {
                List<EstudiosDomain> estudios = new List<EstudiosDomain>();


                using (SqlConnection con = new SqlConnection(stringConexao))
                {

                    string querySelectAll = "SELECT IdEstudio, NomeEstudio FROM Estudios";


                    con.Open();


                    SqlDataReader rdr;


                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {


                        rdr = cmd.ExecuteReader();


                        while (rdr.Read())
                        {


                        


                            EstudiosDomain estudio = new EstudiosDomain
                            {

                                IdEstudio = Convert.ToInt32(rdr["Idestudio"])


                                ,
                                NomeEstudio = rdr[1].ToString()



                            };


                            estudios.Add(estudio);
                        }
                    }
                }

                return estudios;
            }

        
    }
}


