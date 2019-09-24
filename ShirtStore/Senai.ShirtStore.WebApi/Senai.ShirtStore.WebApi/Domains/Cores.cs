using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Cores
    {
        public Cores()
        {
            Camisetas = new HashSet<Camisetas>();
            Estoque = new HashSet<Estoque>();
        }

        public int CorId { get; set; }
        public string Nome { get; set; }

        public ICollection<Camisetas> Camisetas { get; set; }
        public ICollection<Estoque> Estoque { get; set; }
    }
}
