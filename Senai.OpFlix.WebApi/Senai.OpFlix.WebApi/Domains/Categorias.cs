using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Lancamentos = new HashSet<Lancamentos>();
            UsuariosCategorias = new HashSet<UsuariosCategorias>();
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
        public ICollection<UsuariosCategorias> UsuariosCategorias { get; set; }
    }
}
