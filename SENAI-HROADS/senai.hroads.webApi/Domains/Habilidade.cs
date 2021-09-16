using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            Classes = new HashSet<Classe>();
        }

        public short IdHabilidade { get; set; }
        public short? IdTipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoDeHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<Classe> Classes { get; set; }
    }
}
