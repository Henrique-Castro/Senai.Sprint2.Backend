using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    public interface ITamanhosRepository
    {
        void Cadastrar(Tamanhos novoTamanho);
        void Atualizar(Tamanhos tamanhoModificado);
        List<Tamanhos> Listar();
        Tamanhos BuscarPorId(int id);
        void Deletar(int id);
    }
}
