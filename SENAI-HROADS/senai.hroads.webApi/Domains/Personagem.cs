using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagem
    {
        public short IdPersonagem { get; set; }
        public short? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public int CapMaxVida { get; set; }
        public int CapMaxMana { get; set; }
        public DateTime? DataAtt { get; set; }
        public DateTime? DateCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
