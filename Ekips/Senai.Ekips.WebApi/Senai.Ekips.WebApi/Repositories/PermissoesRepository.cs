using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class PermissoesRepository
    {
        public void Cadastrar(Permissoes permissao)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Permissoes.Add(permissao);
                ctx.SaveChanges();
            }
        }
        public List<Permissoes> Listar()
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                return ctx.Permissoes.ToList();
            }
        }
    }
}
