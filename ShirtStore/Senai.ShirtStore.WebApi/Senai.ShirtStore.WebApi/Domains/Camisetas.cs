using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Camisetas
    {
        public Camisetas()
        {
            Estoque = new HashSet<Estoque>();
        }

        public int CamisetaId { get; set; }
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public short Quantidade { get; set; }
        public string Marca { get; set; }
        public string Tamanho { get; set; }

        public Cores CorNavigation { get; set; }
        public Empresas MarcaNavigation { get; set; }
        public Tamanhos TamanhoNavigation { get; set; }
        public ICollection<Estoque> Estoque { get; set; }
    }
}
