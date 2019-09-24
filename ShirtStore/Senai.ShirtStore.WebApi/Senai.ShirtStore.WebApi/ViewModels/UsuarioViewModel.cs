using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int usuarioId, string email, string perfil, string empresa)
        {
            UsuarioId = usuarioId;
            Email = email;
            Perfil = perfil;
            Empresa = empresa;
        }

        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string Empresa { get; set; }
    }
}
