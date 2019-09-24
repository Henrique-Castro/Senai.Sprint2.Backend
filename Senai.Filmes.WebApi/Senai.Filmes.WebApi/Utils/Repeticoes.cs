using Senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Utils
{
    public class Repeticoes
    {
        public static string StringConexao = "Data Source=localhost;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132;";
        public static GeneroRepository GeneroRepository = new GeneroRepository();
        
    }
}
