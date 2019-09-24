using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class UsuariosCategorias
    {
        public UsuariosCategorias(int? idCategoria, int idUsuario)
        {
            IdCategoria = idCategoria;
            IdUsuario = idUsuario;
        }

        public int IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public int Id { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
