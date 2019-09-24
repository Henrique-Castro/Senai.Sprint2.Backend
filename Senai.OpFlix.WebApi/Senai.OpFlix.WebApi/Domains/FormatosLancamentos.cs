using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class FormatosLancamentos
    {
        public FormatosLancamentos()
        {
            Lancamentos = new HashSet<Lancamentos>();
        }

        public int IdFormatoLancamento { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamentos> Lancamentos { get; set; }
    }
}
