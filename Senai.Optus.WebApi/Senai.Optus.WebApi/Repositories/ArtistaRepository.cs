using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        List<Artistas> ListaDeArtistas = new List<Artistas>();

        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.ToList();
            }
        }

        public void Cadastrar(Artistas novoArtista)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Artistas.Add(novoArtista);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Artistas artistaModificado)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Artistas ArtistaBuscado = ctx.Artistas.FirstOrDefault(x => x.IdArtista == artistaModificado.IdArtista);
                ArtistaBuscado.Nome = artistaModificado.Nome;
                ctx.Artistas.Update(ArtistaBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Artistas artistaEncontrado = ctx.Artistas.Find(id);
                ctx.Artistas.Remove(artistaEncontrado);
                ctx.SaveChanges();
            }
        }
        
        public Artistas BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.FirstOrDefault(x => x.IdArtista == id);
            }
        }
        public List<Artistas> BuscarArtistasPorIdEstilo(int id)
        {
            using(OptusContext ctx =new OptusContext())
            {
                return ctx.Artistas
        .Where(x => x.IdEstilo == id)
        .ToList();
            }
        }
        public List<Artistas> BuscarArtistasPorNomeEstilo(string nomeEstilo)
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.Where(x => x.Nome == nomeEstilo).ToList();
            }
        }
    }
}
