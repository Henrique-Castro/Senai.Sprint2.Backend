using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin)
        {
            using(OpflixContext ctx = new OpflixContext())
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

                return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(dadosLogin.Email));               
            }
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            using(OpflixContext ctx = new OpflixContext())
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
    }
}
