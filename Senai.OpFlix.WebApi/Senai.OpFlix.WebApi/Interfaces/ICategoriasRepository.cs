using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ICategoriasRepository
    {
        void Cadastrar(Categorias novaCategoria);
        void Deletar(int id);
        void Deletar(string titulo);
        List<Categorias> Listar();
        void Atualizar(Categorias categoriaModificada);
        void Favoritar(int idUsuario, int idCategoria);
        List<UsuariosCategorias> ListarFavoritos(int idUsuario);
        Categorias BuscarPorNome(string nome);
    }
}
