using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        List<FilmeDomain> ListaDeFilmes = new List<FilmeDomain>();
        private string StringConexao = "Data Source=localhost;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {
            ListaDeFilmes.Clear();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "SELECT IdFilme,Titulo,IdGenero FROM Filmes";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(sdr["IdGenero"])
                        };
                        ListaDeFilmes.Add(filme);
                    }
                }
                //con.Close();
            }
            return ListaDeFilmes;
        }
        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string cadastrarCmd = "INSERT INTO Filmes(Titulo , IdGenero) VALUES (@titulo , @idGenero)";
                using (SqlCommand cmd = new SqlCommand(cadastrarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@idGenero", filme.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public FilmeDomain BuscarPorId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string buscarCmd = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @idFilme";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(buscarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    { 
                        return new FilmeDomain(
                            idFilme: Convert.ToInt32(sdr["IdFilme"]),
                            titulo: sdr["Titulo"].ToString(),
                            idGenero: Convert.ToInt32(sdr["IdGenero"])
                            );
                    }
                    return null;
                }
            }
        }
        public void Atualizar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string atualizarCmd = "UPDATE Filmes SET Titulo = @titulo, IdGenero = @idGenero WHERE IdGenero = @idFilme";
                using (SqlCommand cmd = new SqlCommand(atualizarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@idGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@idfilme", filme.IdFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Deletar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string atualizarCmd = "DELETE FROM Filmes WHERE IdFilmes = @idFilme";
                using (SqlCommand cmd = new SqlCommand(atualizarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", filme.IdFilme);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
