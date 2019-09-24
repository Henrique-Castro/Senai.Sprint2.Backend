using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        List<GeneroDomain> ListaDeGeneros = new List<GeneroDomain>();
        List<FilmeDomain> ListaDeFilmes = new List<FilmeDomain>();
        public List<GeneroDomain> Listar()
        {
            ListaDeGeneros.Clear();

            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                string query = "SELECT IdGenero,Nome FROM Generos";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
               
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GeneroDomain estilo = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        ListaDeGeneros.Add(estilo);
                    }
                    return ListaDeGeneros;
                }
                //con.Close();
            }
            
        }
        public void Cadastrar(GeneroDomain genero)
        {
            using(SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string cadastrarCmd = "INSERT INTO Generos(Nome) VALUES (@NomeFilme)";
                using (SqlCommand cmd = new SqlCommand(cadastrarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@NomeFilme", genero.Nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public GeneroDomain BuscarPorId(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string buscarCmd = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @idGenero";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(buscarCmd , con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        int id = Convert.ToInt32(sdr["IdGenero"]);
                        string nome = sdr["Nome"].ToString();
                        return new GeneroDomain(
                            idGenero: id,
                            nome: nome
                            );
                    }
                    return null;
                }
            }
        }

        public void Atualizar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string atualizarCmd = "UPDATE Generos SET Nome = @nome WHERE IdGenero = @id";
                using (SqlCommand cmd = new SqlCommand(atualizarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@id", genero.IdGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string atualizarCmd = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
                using (SqlCommand cmd = new SqlCommand(atualizarCmd, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", idGenero);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<FilmeDomain> ListarFilmes(int id)
        {
            ListaDeFilmes.Clear();
            using(SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "SELECT F.IdFilme, F.Titulo FROM Filmes F WHERE IdGenero = @idGenero";
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", id);
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ListaDeFilmes.Add(new FilmeDomain(
                            idFilme: Convert.ToInt32(sdr["IdFilme"]),
                            titulo: sdr["Titulo"].ToString(),
                            idGenero: Convert.ToInt32(sdr["IdGenero"])
                            ));
                    }
                    return ListaDeFilmes;
                }
            }
        }
    }
}
