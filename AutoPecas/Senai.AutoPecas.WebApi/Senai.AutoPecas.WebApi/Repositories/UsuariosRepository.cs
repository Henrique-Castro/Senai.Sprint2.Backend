using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(dadosLogin.Email) && x.Senha.Equals(dadosLogin.Senha));
            }
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(novoUsuario);
                ctx.SaveChanges();
            }
        }

        public List<UsuarioViewModel> Listar()
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                List<UsuarioViewModel> listaDeUsuarios = new List<UsuarioViewModel>();
                foreach(var usuario in ctx.Usuarios.ToList())
                {
                    var x = new UsuarioViewModel(
                        email : usuario.Email,
                        usuarioId : usuario.UsuarioId,
                        fornecedorVinculado : ctx.Fornecedores.FirstOrDefault(y => y.UsuarioVinculado == usuario.UsuarioId)
                        );
                    listaDeUsuarios.Add(x);
                }
                return listaDeUsuarios;
            }
        }
        
    }
}
