using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        public List<LivroDomain> ListaDeLivros = new List<LivroDomain>();

        public List<LivroDomain> ListarLivros()
        {
            ListaDeLivros.Clear();
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "SELECT * FROM Livros";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ListaDeLivros.Add(new LivroDomain(
                            idAutor: Convert.ToInt32(sdr["IdAutor"]),
                            titulo: sdr["Titulo"].ToString(),
                            idGenero: Convert.ToInt32(sdr["IdGenero"]),
                            idLivro: Convert.ToInt32(sdr["IdLivro"])
                            ));
                    }
                    return ListaDeLivros;
                }
            }
        }
    }
}
