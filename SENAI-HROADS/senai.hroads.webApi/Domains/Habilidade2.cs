using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade2
    {
        public Habilidade2()
        {
            Classes = new HashSet<Classe>();
        }

        public short IdHabilidade2 { get; set; }
        public short? IdTipoHabilidade { get; set; }
        public string NomeHabilidade2 { get; set; }

        public virtual TipoDeHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<Classe> Classes { get; set; }
    }
}
