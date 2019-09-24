using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface IEmpresasRepository
    {
        void Cadastrar(Empresas novaEmpresa);
        void Atualizar(Empresas empresaModificada);
        void Deletar(int id);
        Empresas BuscarPorId(int id);
        List<Empresas> Listar();
        Empresas BuscarPorNome(string nome);
    }
}
