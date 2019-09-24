using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    public interface ICoresRepository
    {
        void Cadastrar(Cores novaCor);
        void Atualizar(Cores corModificada);
        List<Cores> Listar();
        void Deletar(int id);
        Cores BuscarPorId(int id);
    }
}
