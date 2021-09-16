using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

        public short IdClasse { get; set; }
        public short? IdHabilidade { get; set; }
        public short? IdHabilidade2 { get; set; }
        public string NomeClasse { get; set; }

        public virtual Habilidade2 IdHabilidade2Navigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
