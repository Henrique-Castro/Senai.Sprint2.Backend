using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class LivroDomain
    {

        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public int IdAutor  { get; set; }
        public int IdGenero { get; set; }

        public LivroDomain()
        {

        }

        public LivroDomain(int idLivro, string titulo, int idAutor, int idGenero)
        {
            IdLivro = idLivro;
            Titulo = titulo;
            IdAutor = idAutor;
            IdGenero = idGenero;
        }
    }
}
