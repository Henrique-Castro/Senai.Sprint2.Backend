using System;
using System.Collections.Generic;

namespace Senai.ManuelPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int PecaId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int? FornecedorId { get; set; }

        public Fornecedores Fornecedor { get; set; }
    }
}
