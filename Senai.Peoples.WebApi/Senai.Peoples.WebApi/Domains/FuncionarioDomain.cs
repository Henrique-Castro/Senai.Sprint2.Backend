using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        public FuncionarioDomain()
        {

        }

        public FuncionarioDomain(int idFuncionario, string nome, string sobrenome , DateTime dataNascimento)
        {
            IdFuncionario = idFuncionario;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }
    }
}
