using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class GeneroDomain
    {

        public int Id { get; set; }
        public  string Descricao { get; set; }

        public GeneroDomain()
        {

        }
        public GeneroDomain(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
