using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class Habilidade2Repository : IHabilidade2Repository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idHabilidade2, Habilidade2 Habilidade2Atualizada)
        {
            Habilidade2 Habilidade2Buscado = ctx.Habilidade2s.Find(idHabilidade2);

            if (Habilidade2Atualizada.NomeHabilidade2 != null)
            {
                Habilidade2Buscado.NomeHabilidade2 = Habilidade2Atualizada.NomeHabilidade2;

                ctx.Habilidade2s.Update(Habilidade2Buscado);

                ctx.SaveChanges();
            }
        }

        public Habilidade2 BuscarPorId(int idHabilidade2)
        {
            return ctx.Habilidade2s.FirstOrDefault(e => e.IdHabilidade2 == idHabilidade2);
        }

        public void Cadastrar(Habilidade2 novaHabilidade2)
        {
            ctx.Habilidade2s.Add(novaHabilidade2);
            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade2)
        {
            ctx.Habilidade2s.Remove(BuscarPorId(idHabilidade2));

            ctx.SaveChanges();
        }

        public List<Habilidade2> Listar()
        {
            return ctx.Habilidade2s.ToList();
        }

        public List<Habilidade2> ListarComTipoHabilidade()
        {
            return ctx.Habilidade2s.Include(e => e.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
