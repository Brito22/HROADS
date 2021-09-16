using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoDeHabilidadeRepository : ITipoDeHabilidadeRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idTipoDeHabilidade, TipoDeHabilidade TipoDeHabilidadeAtualizado)
        {
            TipoDeHabilidade TipoDeHabilidadeBuscado = ctx.TipoDeHabilidades.Find(idTipoDeHabilidade);

            if (TipoDeHabilidadeAtualizado.NomeTipoHabilidade != null)
            {
                TipoDeHabilidadeBuscado.NomeTipoHabilidade = TipoDeHabilidadeAtualizado.NomeTipoHabilidade;

                ctx.TipoDeHabilidades.Update(TipoDeHabilidadeBuscado);

                ctx.SaveChanges();
            }
        }

        public TipoDeHabilidade BuscarPorId(int idTipoDeHabilidade)
        {
            return ctx.TipoDeHabilidades.FirstOrDefault(e => e.IdTipoHabilidade == idTipoDeHabilidade);
        }

        public void Cadastrar(TipoDeHabilidade novoTipoDeHabilidade)
        {
            ctx.TipoDeHabilidades.Add(novoTipoDeHabilidade);
            ctx.SaveChanges();
        }

        public void Deletar(int idTipoDeHabilidade)
        {
            ctx.TipoDeHabilidades.Remove(BuscarPorId(idTipoDeHabilidade));

            ctx.SaveChanges();
        }

        public List<TipoDeHabilidade> Listar()
        {
            return ctx.TipoDeHabilidades.ToList();
        }
    }
}
