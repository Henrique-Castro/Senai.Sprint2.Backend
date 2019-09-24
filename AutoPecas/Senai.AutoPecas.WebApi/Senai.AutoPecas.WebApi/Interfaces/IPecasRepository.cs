using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecasRepository
    {
        List<Pecas> ListarTodas();
        List<Pecas> ListarPecasPorFornecedor(int idFornecedor);
        Pecas BuscarPecaPorCodigo(int codigo);
        void Cadastrar(Pecas novaPeca);
        void Atualizar(Pecas pecaModificada);
        void Deletar(int codigo);
        List<string> ValorGanhos();
        string CalcularPedido(int codigo, int quantidade);
    }
}
