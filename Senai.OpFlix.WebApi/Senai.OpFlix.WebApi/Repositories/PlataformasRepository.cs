using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformasRepository : IPlataformasRepository
    {
        public void Atualizar(Plataformas plataformaModificada)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Plataformas plataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == plataformaModificada.IdPlataforma);

                plataformaBuscada.Nome = plataformaModificada.Nome;

                ctx.Plataformas.Update(plataformaBuscada);
                ctx.SaveChanges();     
            }
        }

        public Plataformas BuscarPorNome(string nome)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.Plataformas.FirstOrDefault(x => x.Nome.Equals(nome));
            }
        }

        public void Cadastrar(Plataformas novaPlataforma)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                ctx.Plataformas.Add(novaPlataforma);
                ctx.SaveChanges();
            }
        }

        public List<Plataformas> Listar()
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }
    }
}
