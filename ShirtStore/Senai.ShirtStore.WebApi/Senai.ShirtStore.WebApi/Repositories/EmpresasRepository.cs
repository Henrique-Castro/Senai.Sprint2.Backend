using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        public void Atualizar(Empresas empresaModificada)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                Empresas EmpresaBuscada = BuscarPorId(empresaModificada.EmpresaId);
                if (EmpresaBuscada != null)
                {
                    EmpresaBuscada.Nome = empresaModificada.Nome != null ? empresaModificada.Nome : EmpresaBuscada.Nome;
                }
                else
                {
                    throw new Exception(message: "Este usuário não existe ou não pôde ser encontrado.");
                }
            }
        }

        public Empresas BuscarPorId(int id)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                return ctx.Empresas.Find(id);
            }
        }

        public Empresas BuscarPorNome(string nome)
        {
            using(ShirtContext ctx = new ShirtContext())
            {
                return ctx.Empresas.FirstOrDefault(x => x.Nome.Equals(nome));
            }
        }

        public void Cadastrar(Empresas novoUsuario)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                ctx.Empresas.Add(novoUsuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                ctx.Empresas.Remove(BuscarPorId(id));
                ctx.SaveChanges();
            }
        }

        public List<Empresas> Listar()
        {
            using (ShirtContext ctx = new ShirtContext())
            {
                return ctx.Empresas.ToList();
            }
        }
    }
}
