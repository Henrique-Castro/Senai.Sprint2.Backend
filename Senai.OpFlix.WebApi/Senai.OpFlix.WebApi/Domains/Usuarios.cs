using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            FotosUsuarios = new HashSet<FotosUsuarios>();
            UsuariosCategorias = new HashSet<UsuariosCategorias>();
            UsuariosLancamentos = new HashSet<UsuariosLancamentos>();
        }

        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<FotosUsuarios> FotosUsuarios { get; set; }
        public ICollection<UsuariosCategorias> UsuariosCategorias { get; set; }
        public ICollection<UsuariosLancamentos> UsuariosLancamentos { get; set; }
    }
}
