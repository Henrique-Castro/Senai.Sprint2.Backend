using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IFormatosRepository
    {
        void Cadastrar(FormatosLancamentos novoFormato);
        void Deletar(int id);
        List<FormatosLancamentos> Listar();
        void Atualizar(FormatosLancamentos formatoModificado);
    }
}
