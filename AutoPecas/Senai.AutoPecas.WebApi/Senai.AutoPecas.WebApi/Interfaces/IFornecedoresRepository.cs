using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IFornecedoresRepository
    {
        void Cadastrar(Fornecedores novoFornecedor);
        Fornecedores BuscarPorId(int id);
        void Deletar(int IdFornecedor);
        List<Fornecedores> ListarTodos();
        Fornecedores BuscarPorIdUsuarioVinculado(int id);
    }
}
