using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == dadosLogin.Email && x.Senha == dadosLogin.Senha);
                return usuario == null ? null : usuario;
            }
        }
    }
}
