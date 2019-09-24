using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios novoUsuario);
        Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin);
    }
}
