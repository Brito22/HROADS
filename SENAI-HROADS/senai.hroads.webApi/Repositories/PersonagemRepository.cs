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
    public class PersonagemRepository : IPersonagemRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idPersonagem, Personagem PersonagemAtualizado)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(Convert.ToInt16(idPersonagem));

            if (PersonagemAtualizado.NomePersonagem != null)
            {
                PersonagemBuscado.NomePersonagem = PersonagemAtualizado.NomePersonagem;

                ctx.Personagems.Update(PersonagemBuscado);

                ctx.SaveChanges();
            }
        }

        public Personagem BuscarPorId(int idPersonagem)
        {
            return ctx.Personagems.FirstOrDefault(e => e.IdPersonagem == idPersonagem);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            ctx.Personagems.Add(novoPersonagem);
            ctx.SaveChanges();
        }

        public void Deletar(int idPersonagem)
        {
            ctx.Personagems.Remove(BuscarPorId(idPersonagem));

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.ToList();
        }

        public List<Personagem> ListarComClasse()
        {
            return ctx.Personagems.Include(e => e.IdClasseNavigation).ToList();
        }
    }
}
