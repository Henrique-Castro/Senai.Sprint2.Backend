using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string Empresa { get; set; }

        public Empresas EmpresaNavigation { get; set; }
        public Perfis PerfilNavigation { get; set; }
    }
}
