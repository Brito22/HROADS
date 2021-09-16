using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
      
        List<Classe> Listar();

       
        Classe BuscarPorId(int idClasse);


        void Cadastrar(Classe novaClasse);

        void Atualizar(int idClasse, Classe ClasseAtualizada);

     
        void Deletar(int idClasse);

      
        List<Classe> ListarComHabilidades();
    }
}
