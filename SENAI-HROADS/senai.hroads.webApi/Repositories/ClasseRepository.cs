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
    public class ClasseRepository : IClasseRepository
    {
        HROADSContext ctx = new HROADSContext();

        public void Atualizar(int idClasse, Classe ClasseAtualizada)
        {
            Classe ClasseBuscado = ctx.Classes.Find(idClasse);

            if (ClasseAtualizada.NomeClasse != null)
            {
                ClasseBuscado.NomeClasse = ClasseAtualizada.NomeClasse;

                ctx.Classes.Update(ClasseBuscado);

                ctx.SaveChanges();
            }
        }

        public Classe BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(e => e.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);
            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            ctx.Classes.Remove(BuscarPorId(idClasse));

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }

        public List<Classe> ListarComHabilidades()
        {
            return ctx.Classes.Include(e => e.Personagems).ToList();
        }
    }
}
