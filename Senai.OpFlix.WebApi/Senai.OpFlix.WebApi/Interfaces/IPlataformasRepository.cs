using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IPlataformasRepository
    {
        void Cadastrar(Plataformas novaPlataforma);
        List<Plataformas> Listar();
        void Atualizar(Plataformas plataformaModificada);
        Plataformas BuscarPorNome(string nome);
    }
}
