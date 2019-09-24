using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class CamisetasRepository : ICamisetasRepository
    {
        public void Atualizar(Camisetas camisetaModificada)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                Camisetas camisetaBuscada = BuscarPorId(camisetaModificada.CamisetaId);

                if (camisetaBuscada != null)
                {
                    camisetaBuscada.Cor = camisetaModificada.Cor == null ? camisetaBuscada.Cor : camisetaModificada.Cor;
                    camisetaBuscada.Descricao = camisetaModificada.Descricao == null ? camisetaBuscada.Descricao : camisetaModificada.Descricao;
                    camisetaBuscada.Marca = camisetaModificada.Marca == null ? camisetaBuscada.Marca : camisetaModificada.Marca;
                    camisetaBuscada.Quantidade = camisetaModificada.Quantidade;

                    ctx.Camisetas.Update(camisetaBuscada);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception(message: "Esta camiseta não está cadastrada ou não pôde ser encontrada.");
            }
        }

        public Camisetas BuscarPorId(int id)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                return ctx.Camisetas.Find(id);
            }
        }

        public void Cadastrar(Camisetas novaCamiseta)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                /*Estoque novoRegistro = new Estoque(
                    camisetaId : novaCamiseta.CamisetaId,
                    tamanhos : novaCamiseta.
                    );*/
                ctx.Camisetas.Add(novaCamiseta);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                ctx.Camisetas.Remove(BuscarPorId(id));
            }
        }

        public List<Camisetas> Listar()
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Camisetas.ToList();
            }
        }
    }
}
