using System;
using System.Collections.Generic;

namespace Senai.ManuelPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public Fornecedores()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Pecas> Pecas { get; set; }
    }
}
