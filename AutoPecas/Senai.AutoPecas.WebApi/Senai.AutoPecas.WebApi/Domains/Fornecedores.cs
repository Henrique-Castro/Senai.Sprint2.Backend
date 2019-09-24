using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public Fornecedores()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int FornecedorId { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int UsuarioVinculado { get; set; }

        public Usuarios UsuarioVinculadoNavigation { get; set; }
        public ICollection<Pecas> Pecas { get; set; }
    }
}
