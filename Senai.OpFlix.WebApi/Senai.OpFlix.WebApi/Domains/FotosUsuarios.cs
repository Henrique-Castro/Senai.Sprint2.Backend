using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class FotosUsuarios
    {
        public int IdUsuario { get; set; }
        public byte[] Imagem { get; set; }
        public int Id { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
