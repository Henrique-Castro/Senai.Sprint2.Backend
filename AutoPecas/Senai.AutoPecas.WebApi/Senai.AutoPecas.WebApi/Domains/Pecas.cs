using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int PecaId { get; set; }
        public int PecaCodigo { get; set; }
        public string Descricao { get; set; }
        public double Peso { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int FornecedorId { get; set; }

        public Fornecedores Fornecedor { get; set; }
    }
}
