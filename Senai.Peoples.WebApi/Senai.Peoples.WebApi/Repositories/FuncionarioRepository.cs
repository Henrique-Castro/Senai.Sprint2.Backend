using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=localhost;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";
        private List<FuncionarioDomain> ListaDeFuncionarios = new List<FuncionarioDomain>();

        public void Cadastrar(FuncionarioDomain funcionarioNovo)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string insertQuery = "INSERT INTO Funcionarios(Nome , Sobrenome , DataNascimento) VALUES (@nome , @sobrenome , @dataNascimento)";
                using(SqlCommand cmd = new SqlCommand(insertQuery , con))
                {
                    cmd.Parameters.AddWithValue("@nome" , funcionarioNovo.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionarioNovo.Sobrenome);
                    cmd.Parameters.AddWithValue("@dataNacimento", funcionarioNovo.DataNascimento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            ListaDeFuncionarios.Clear();
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                string selecionarListaQuery = "SELECT IdFuncionario , Nome , Sobrenome , DataNascimento FROM Funcionarios";
                using(SqlCommand cmd = new SqlCommand(selecionarListaQuery , con))
                {
                    sdr = cmd.ExecuteReader();
                    
                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionarioRecuperado = new FuncionarioDomain
                        (
                            nome : sdr["Nome"].ToString(),
                            sobrenome : sdr["Sobrenome"].ToString(),
                            dataNascimento : DateTime.Parse(sdr["DataNascimento"].ToString()),
                            idFuncionario : Convert.ToInt32(sdr["IdFuncionario"])
                        );
                            
                        ListaDeFuncionarios.Add(funcionarioRecuperado);
                        
                    }
                    return ListaDeFuncionarios;
                }
            } 
        }

        public FuncionarioDomain BuscarPorId(int idFuncionario)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string selecionarPorIdQuery = "SELECT IdFuncionario , Nome , Sobrenome , DataNascimento FROM Funcionarios WHERE IdFuncionario = @idFuncionario";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(selecionarPorIdQuery , con))
                {
                    cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        return new FuncionarioDomain(
                                idFuncionario : Convert.ToInt32(sdr["IdFuncionario"]) ,
                                nome : sdr["Nome"].ToString() , 
                                sobrenome : sdr["Sobrenome"].ToString(),
                                dataNascimento : Convert.ToDateTime(sdr["dataNascimento"])
                            );
                    }
                    return null;
                }
            }
        }

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string selecionarPorIdQuery = "SELECT IdFuncionario , Nome , Sobrenome , DataNascimento FROM Funcionarios WHERE Nome = @nome";
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(selecionarPorIdQuery, con))
                {
                    cmd.Parameters.AddWithValue("@idFuncionario", nome);
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        return new FuncionarioDomain(
                                idFuncionario: Convert.ToInt32(sdr["IdFuncionario"]),
                                nome: sdr["Nome"].ToString(),
                                sobrenome: sdr["Sobrenome"].ToString(),
                                dataNascimento: Convert.ToDateTime(sdr["dataNascimento"])
                            );
                    }
                    return null;
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionario)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string updateQuery = "UPDATE Funcionarios SET Nome = @nome , Sobrenome = @sobrenome , DataNascimento = @dataNascimento WHERE IdFuncionario = @idFuncionario";
                using(SqlCommand cmd = new SqlCommand(updateQuery , con))
                {
                    cmd.Parameters.AddWithValue("@idFuncionario", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@dataNascimento", funcionario.DataNascimento);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar (FuncionarioDomain funcionario)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string deleteQuery = "DELETE FROM Funcionarios WHERE IdFuncionario = @idFuncionario";

                using(SqlCommand cmd = new SqlCommand(deleteQuery , con))
                {
                    cmd.Parameters.AddWithValue("@idFuncionario", funcionario.IdFuncionario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
