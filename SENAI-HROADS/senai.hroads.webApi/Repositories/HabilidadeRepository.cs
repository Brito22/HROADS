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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();
        public void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada)
        {
            Habilidade HabilidadeBuscado = ctx.Habilidades.Find(idHabilidade);

            if (HabilidadeAtualizada.NomeHabilidade != null)
            {
                HabilidadeBuscado.NomeHabilidade = HabilidadeAtualizada.NomeHabilidade;

                ctx.Habilidades.Update(HabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(e => e.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            ctx.Habilidades.Remove(BuscarPorId(idHabilidade));

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }

        public List<Habilidade> ListarComTipoHabilidade()
        {
            return ctx.Habilidades.Include(e => e.IdTipoHabilidadeNavigation).ToList();
        }
    }
}
