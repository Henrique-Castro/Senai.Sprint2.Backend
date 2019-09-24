using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Empresas
    {
        public Empresas()
        {
            Camisetas = new HashSet<Camisetas>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int EmpresaId { get; set; }
        public string Nome { get; set; }

        public ICollection<Camisetas> Camisetas { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
