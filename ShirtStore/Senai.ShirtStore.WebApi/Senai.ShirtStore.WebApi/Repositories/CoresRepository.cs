using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class CoresRepository : ICoresRepository
    {
        public void Atualizar(Cores corModificada)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                Cores corBuscada = BuscarPorId(corModificada.CorId);

                if(corBuscada != null)
                {
                    corBuscada.Nome = corModificada.Nome;

                    ctx.Cores.Update(corBuscada);
                }
                else
                {
                    throw new Exception(message: "Cor não encontrada");
                }
            }
        }

        public Cores BuscarPorId(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Cores.Find(id);
            }
        }

        public void Cadastrar(Cores novaCor)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                if (!ctx.Cores.ToList().Contains(novaCor))
                { 
                    ctx.Cores.Add(novaCor);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception(message: "Esta cor já foi cadastrada, tente uma diferente.");
            }
        }

        public void Deletar(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                if (BuscarPorId(id) != null)
                {
                    ctx.Cores.Remove(BuscarPorId(id));
                    ctx.SaveChanges();
                }
                else
                    throw new Exception(message: "Esta cor não está cadastrada pu não pôde ser encontrada.");

            }
        }

        public List<Cores> Listar()
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Cores.ToList();
            }
        }
    }
}
