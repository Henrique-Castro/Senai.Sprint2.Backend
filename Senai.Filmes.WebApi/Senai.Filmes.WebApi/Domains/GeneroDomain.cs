using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class GeneroDomain
    {
        public int IdGenero { get; set ; }
        [Required(ErrorMessage = "É obrigatório informar o nome do gênero.")]
        public string Nome { get; set; }

       public GeneroDomain() { }

        public GeneroDomain(int idGenero , string nome)
        {
            IdGenero = idGenero;
            Nome = nome;
        }
    }
}

