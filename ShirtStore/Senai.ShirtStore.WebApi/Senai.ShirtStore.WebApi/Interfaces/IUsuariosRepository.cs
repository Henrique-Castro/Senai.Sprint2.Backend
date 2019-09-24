using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios novoUsuario);
        void Atualizar(Usuarios usuarioModificado);
        void Deletar(int id);
        Usuarios BuscarPorId(int id);
        List<UsuarioViewModel> Listar();
        Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin);
    }
}
