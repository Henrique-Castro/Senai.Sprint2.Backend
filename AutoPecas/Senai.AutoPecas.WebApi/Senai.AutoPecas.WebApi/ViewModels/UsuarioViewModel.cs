using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        Fornecedores FornecedorVinculado { get; set; }
        public ICollection<Fornecedores> Fornecedores { get; set; }

        public UsuarioViewModel(int usuarioId, string email, Fornecedores fornecedorVinculado)
        {
            UsuarioId = usuarioId;
            Email = email;
            FornecedorVinculado = fornecedorVinculado;
        }
    }
}
