using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TipoDeHabilidade
    {
        public TipoDeHabilidade()
        {
            Habilidade2s = new HashSet<Habilidade2>();
            Habilidades = new HashSet<Habilidade>();
        }

        public short IdTipoHabilidade { get; set; }
        public string NomeTipoHabilidade { get; set; }

        public virtual ICollection<Habilidade2> Habilidade2s { get; set; }
        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
