using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        public void Atualizar(Categorias categoriaModificada)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoriaModificada.IdCategoria);

                categoriaBuscada.Descricao = categoriaModificada.Descricao;
                categoriaBuscada.Nome = categoriaModificada.Nome;

                ctx.Categorias.Update(categoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorNome(string nome)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categorias.First(x => x.Nome.Equals(nome));
            }
        }

        public void Cadastrar(Categorias novaCategoria)
        {
           using(OpflixContext ctx = new OpflixContext())
            {
                ctx.Categorias.Add(novaCategoria);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Categorias.Remove(ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id));
                ctx.SaveChanges();
            }
        }

        public void Deletar(string titulo)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Categorias.Remove(ctx.Categorias.FirstOrDefault(x => x.Nome.Equals(titulo)));
                ctx.SaveChanges();
            }
        }

        public void Favoritar(int idUsuarioLogado, int idCategoriaFavortitada)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                UsuariosCategorias favoritado = new UsuariosCategorias(
                    idCategoria : idCategoriaFavortitada,
                    idUsuario : idUsuarioLogado
                    );
                ctx.UsuariosCategorias.Add(favoritado);
                ctx.SaveChanges();
            }
        }

        public List<Categorias> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categorias.ToList();
            }
        }

        public List<UsuariosCategorias> ListarFavoritos(int idUsuario)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.UsuariosCategorias.Where(x => x.IdUsuario == idUsuario).ToList();
            }
        }
    }
}
