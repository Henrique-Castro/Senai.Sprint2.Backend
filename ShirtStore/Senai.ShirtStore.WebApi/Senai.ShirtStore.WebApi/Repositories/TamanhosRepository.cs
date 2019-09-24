using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class TamanhosRepository : ITamanhosRepository
    {
        public void Atualizar(Tamanhos tamanhoModificado)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                Tamanhos tamanhoBuscado = BuscarPorId(tamanhoModificado.TamanhoId);

                if (tamanhoBuscado != null)
                {
                    tamanhoBuscado.Nome = tamanhoModificado.Nome != null ? tamanhoModificado.Nome : tamanhoBuscado.Nome;
                    tamanhoBuscado.Sigla = tamanhoModificado.Sigla != null ? tamanhoModificado.Sigla : tamanhoBuscado.Sigla;

                    ctx.Tamanhos.Update(tamanhoBuscado);
                    ctx.SaveChanges();
                }
                else
                    throw new Exception(message: "Tamanho não foi cadastrado ou não pôde ser encontrado.");
            }
        }

        public Tamanhos BuscarPorId(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Tamanhos.Find(id);
            }
        }

        public void Cadastrar(Tamanhos novoTamanho)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                ctx.Tamanhos.Add(novoTamanho);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                ctx.Tamanhos.Remove(BuscarPorId(id));
            }
        }

        public List<Tamanhos> Listar()
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Tamanhos.ToList();
            }
        }
    }
}
