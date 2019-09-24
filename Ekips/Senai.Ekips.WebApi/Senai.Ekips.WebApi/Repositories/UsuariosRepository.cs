using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public void Cadastrar(Usuarios usuario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
        public List<Usuarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        public Usuarios Login(LoginViewModel dadosLogin)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.First(x => x.Email == dadosLogin.Email && x.Senha == dadosLogin.Senha);
                return usuarioBuscado == null ? null : usuarioBuscado;
            }
        }
    }
}
