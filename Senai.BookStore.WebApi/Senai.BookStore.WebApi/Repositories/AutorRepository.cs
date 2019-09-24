using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        public static List<AutorDomain> ListaDeAutores = new List<AutorDomain>();

        public List<AutorDomain> ListarAutores()
        {
            ListaDeAutores.Clear();
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "SELECT IdAutor, Nome, Ativo FROM Autores";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ListaDeAutores.Add(new AutorDomain(
                            idAutor: Convert.ToInt32(sdr["IdAutor"]),
                            nome: sdr["Nome"].ToString(),
                            email: sdr["Email"].ToString(),
                            ativo: Convert.ToBoolean(sdr["Ativo"]),
                            dataNascimento: Convert.ToDateTime(sdr["DataNascimento"])
                            ));
                    }
                    return ListaDeAutores;
                }
            }
        }

        public void Cadastrar(AutorDomain autor)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "INSERT INTO Autores(IdAutor, Nome, Email, Ativo, DataNascimento) VALUES (@idAutor, @nome, @email, @ativo, @dataNascimento)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idAutor", autor.IdAutor);
                    cmd.Parameters.AddWithValue("@nome", autor.Nome);
                    cmd.Parameters.AddWithValue("@email", autor.Email);
                    cmd.Parameters.AddWithValue("@ativo", autor.Ativo);
                    cmd.Parameters.AddWithValue("@idAutor", autor.IdAutor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AutorDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "SELECT IdGenero, Descricao FROM Generos WHERE IdGenero = @id";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    sdr = cmd.ExecuteReader();

                    return sdr.Read() ? new AutorDomain(
                            idAutor: Convert.ToInt32(sdr["IdAutor"]),
                            nome: sdr["Nome"].ToString(),
                            email: sdr["Email"].ToString(),
                            ativo: Convert.ToBoolean(sdr["Ativo"]),
                            dataNascimento: Convert.ToDateTime(sdr["DataNascimento"])
                            ) : null;
                }
            }
        }
    }
}
