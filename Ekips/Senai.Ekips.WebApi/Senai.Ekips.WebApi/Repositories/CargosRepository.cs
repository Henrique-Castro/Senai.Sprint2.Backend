using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargosRepository
    {
        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }

        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }
        }

        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.Find(id);
            }
        }

        public void Atualizar(Cargos cargoModificado)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos cargoEncontrado = BuscarPorId(cargoModificado.IdCargo);
                if (cargoEncontrado == null)
                    throw new System.ArgumentException("Este cargo provavelmente não existe.");

                cargoEncontrado.Nome = cargoModificado.Nome;
                
                ctx.Cargos.Update(cargoEncontrado);
                ctx.SaveChanges();
            }
        }
    }
}
