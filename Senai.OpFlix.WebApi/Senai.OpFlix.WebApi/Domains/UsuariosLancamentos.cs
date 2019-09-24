using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class UsuariosLancamentos
    {
        public UsuariosLancamentos(int idUsuario, int? idLancamento)
        {
            IdUsuario = idUsuario;
            IdLancamento = idLancamento;
        }

        public int IdUsuario { get; set; }
        public int? IdLancamento { get; set; }
        public int Id { get; set; }

        public Lancamentos IdLancamentoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
