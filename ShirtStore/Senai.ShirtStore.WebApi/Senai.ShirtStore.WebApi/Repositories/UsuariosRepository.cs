using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public void Atualizar(Usuarios usuarioModificado)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                Usuarios UsuarioBuscado = BuscarPorId(usuarioModificado.UsuarioId);
                if(UsuarioBuscado != null)
                {
                    UsuarioBuscado.Perfil = usuarioModificado.Perfil != null ? usuarioModificado.Perfil : UsuarioBuscado.Perfil;
                    UsuarioBuscado.Senha = usuarioModificado.Senha != null ? usuarioModificado.Senha : UsuarioBuscado.Senha;
                    UsuarioBuscado.Email = usuarioModificado.Email != null ? usuarioModificado.Email : UsuarioBuscado.Email;
                    UsuarioBuscado.Empresa = usuarioModificado.Empresa != null ? usuarioModificado.Empresa : UsuarioBuscado.Empresa;

                    ctx.Usuarios.Update(UsuarioBuscado);
                    ctx.SaveChanges();
                }
                else
                {
                    throw new Exception(message: "Este usuário não existe ou não pode ser encontrado.");
                }
            }
        }

        public Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                string savedPasswordHash = ctx.Usuarios.FirstOrDefault(u => u.Email.Equals(dadosLogin.Email)).Senha;
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(dadosLogin.Senha, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        throw new UnauthorizedAccessException();

                Usuarios UsuarioEncontrado = ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(dadosLogin.Email));
                if(UsuarioEncontrado == null)
                {
                    throw new Exception(message: "Email ou senha estão incorretos.");
                }
                return UsuarioEncontrado;
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Usuarios.Find(id);
            }
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                var pbkdf2 = new Rfc2898DeriveBytes(novoUsuario.Senha, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                string savedPasswordHash = Convert.ToBase64String(hashBytes);

                novoUsuario.Senha = savedPasswordHash;

                ctx.Usuarios.Add(novoUsuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                ctx.Usuarios.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
        }

        public List<UsuarioViewModel> Listar()
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                List<UsuarioViewModel> ListaDeUsuarios = new List<UsuarioViewModel>();
                foreach(var usuario in ctx.Usuarios)
                {
                    UsuarioViewModel usuarioViewModel = new UsuarioViewModel(
                        email : usuario.Email,
                        usuarioId : usuario.UsuarioId,
                        perfil : usuario.Perfil,
                        empresa : usuario.Empresa
                        );
                    ListaDeUsuarios.Add(usuarioViewModel);
                }
                return ListaDeUsuarios;
            }
        }
    }
}
