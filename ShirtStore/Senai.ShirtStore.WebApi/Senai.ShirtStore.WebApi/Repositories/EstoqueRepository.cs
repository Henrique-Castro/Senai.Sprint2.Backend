using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        public void Cadastrar(Estoque novoRegistro)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                ctx.Estoque.Add(novoRegistro);
                ctx.SaveChanges();
            }
        }
    }
}
