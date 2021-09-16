using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidade2Repository
    {
        List<Habilidade2> Listar();


        Habilidade2 BuscarPorId(int idHabilidade2);


        void Cadastrar(Habilidade2 novaHabilidade2);

        void Atualizar(int idHabilidade2, Habilidade2 Habilidade2Atualizada);


        void Deletar(int idHabilidade2);


        List<Habilidade2> ListarComTipoHabilidade();
    }
}
