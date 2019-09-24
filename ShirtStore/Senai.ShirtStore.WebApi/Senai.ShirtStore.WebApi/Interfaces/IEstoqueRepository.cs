using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    public interface IEstoqueRepository
    {
        void Cadastrar(Estoque novoRegistro);
    }
}
