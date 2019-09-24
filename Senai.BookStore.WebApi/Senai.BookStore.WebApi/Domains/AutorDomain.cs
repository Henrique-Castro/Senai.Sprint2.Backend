using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class AutorDomain
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }

        public AutorDomain()
        {

        }
        public AutorDomain(int idAutor, string nome, string email, bool ativo, DateTime dataNascimento)
        {
            IdAutor = idAutor;
            Nome = nome;
            Email = email;
            Ativo = ativo;
            DataNascimento = dataNascimento;
        }

    }
}
