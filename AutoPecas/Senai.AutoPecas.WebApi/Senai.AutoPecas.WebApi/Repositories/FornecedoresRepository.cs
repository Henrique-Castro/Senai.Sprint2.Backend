using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedoresRepository : IFornecedoresRepository
    {
        public Fornecedores BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.FirstOrDefault(x => x.FornecedorId == id);
            }
        }

        public Fornecedores BuscarPorIdUsuarioVinculado(int id)
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.FirstOrDefault(x => x.UsuarioVinculado == id);
            }
        }

        public void Cadastrar(Fornecedores novoFornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(novoFornecedor);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int IdFornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Remove(BuscarPorId(IdFornecedor));
                ctx.SaveChanges();
            }
        }

        public List<Fornecedores> ListarTodos()
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.ToList();
            }
        }
    }
}
