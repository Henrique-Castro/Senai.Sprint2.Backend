using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel dadosDeLogin)
        {
            using(GufosContext ctx = new GufosContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == dadosDeLogin.Email & x.Senha == dadosDeLogin.Senha);

                return usuario == null ? null : usuario;
            }
        }
    }
}
