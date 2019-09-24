using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    
        public void Cadastrar(Categorias categoria)
        {
            using(GufosContext ctx = new GufosContext())
            {
                //insert into Categorias
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }
        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }
        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                //encontrar o item 
                //chave primaria da tabela
                Categorias Categoria = ctx.Categorias.Find(id);
                //remover do contexto
                ctx.Categorias.Remove(Categoria);
                //efetivar as mudanças no banco de dados
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Categorias categoriaModificada)
        {
            using(GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoriaModificada.IdCategoria);
             
                CategoriaBuscada.Nome = categoriaModificada.Nome;
                
                ctx.Categorias.Update(CategoriaBuscada);
            
                ctx.SaveChanges();
            }
        }
    }
}
