using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        List<Estilos> ListaDeEstilos = new List<Estilos>();

        public List<Estilos> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos novoEstilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(novoEstilo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estilos estiloModificado)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estiloModificado.IdEstilo);
                EstiloBuscado.Nome = estiloModificado.Nome;
                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos estiloEncontrado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(estiloEncontrado);
                ctx.SaveChanges();
            }
        }
    }
}
