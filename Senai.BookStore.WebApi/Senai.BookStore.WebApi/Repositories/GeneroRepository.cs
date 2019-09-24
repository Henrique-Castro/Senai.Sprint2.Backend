using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        List<GeneroDomain> ListaDeGeneros = new List<GeneroDomain>();

        public List<GeneroDomain> ListarGeneros()
        {
            ListaDeGeneros.Clear();
            using(SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "SELECT IdGenero, Descricao FROM Generos";
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ListaDeGeneros.Add(new GeneroDomain(
                            id: Convert.ToInt32(sdr["IdGenero"]),
                            descricao: sdr["Descricao"].ToString()
                            ));
                    }
                    return ListaDeGeneros;
                }
            }
        }
        
        public void Cadastrar(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(Utils.Repeticoes.StringConexao))
            {
                con.Open();
                string query = "INSERT INTO Generos(Descricao) VALUES (@descricao)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@descricao", genero.Descricao);
                    cmd.ExecuteNonQuery();
                }
            }
            }

        public GeneroDomain BuscarPorId(int id)
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

                    return sdr.Read() ? new GeneroDomain(
                        id: Convert.ToInt32(sdr["IdGenero"]),
                        descricao: sdr["Descricao"].ToString()
                        ) : null;
                }
            }
        }


    }
}
