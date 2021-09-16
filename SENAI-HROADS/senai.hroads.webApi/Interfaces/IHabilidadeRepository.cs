using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();


        Habilidade BuscarPorId(int idHabilidade);


        void Cadastrar(Habilidade novaHabilidade);

        void Atualizar(int idHabilidade, Habilidade HabilidadeAtualizada);


        void Deletar(int idHabilidade);


        List<Habilidade> ListarComTipoHabilidade();
    }
}
