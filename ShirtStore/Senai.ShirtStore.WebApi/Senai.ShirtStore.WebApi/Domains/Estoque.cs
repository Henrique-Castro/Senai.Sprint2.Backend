using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Estoque
    {
        public int Id { get; set; }
        public int? CamisetaId { get; set; }
        public string Tamanhos { get; set; }
        public string Cores { get; set; }

        public Camisetas Camiseta { get; set; }
        public Cores CoresNavigation { get; set; }
        public Tamanhos TamanhosNavigation { get; set; }
    }
}
