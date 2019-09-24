using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class FilmeDomain
    {
        public FilmeDomain()
        {

        }
        public FilmeDomain(int idFilme, string titulo, int idGenero)
        {
            IdFilme = idFilme;
            Titulo = titulo;
            IdGenero = idGenero;
        }

        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int IdGenero { get; set; }

    }
}
