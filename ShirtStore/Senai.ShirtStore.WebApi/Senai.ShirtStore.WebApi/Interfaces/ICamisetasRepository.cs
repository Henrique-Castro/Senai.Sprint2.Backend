using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface ICamisetasRepository
    {
        void Cadastrar(Camisetas novaCamiseta);
        void Deletar(int id);
        List<Camisetas> Listar();
        void Atualizar(Camisetas camisetaModificada);
        Camisetas BuscarPorId(int id);
    }
}
