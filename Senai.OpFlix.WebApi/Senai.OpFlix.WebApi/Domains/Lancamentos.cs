using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public Lancamentos()
        {
            UsuariosLancamentos = new HashSet<UsuariosLancamentos>();
        }

        public int IdLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Categoria { get; set; }
        public short Duracao { get; set; }
        public int? Formato { get; set; }
        public DateTime Estreia { get; set; }
        public int QtdEpisodios { get; set; }
        public int? Plataforma { get; set; }
        public bool? Visivel { get; set; }

        public Categorias CategoriaNavigation { get; set; }
        public FormatosLancamentos FormatoNavigation { get; set; }
        public Plataformas PlataformaNavigation { get; set; }
        public ICollection<UsuariosLancamentos> UsuariosLancamentos { get; set; }
    }
}
