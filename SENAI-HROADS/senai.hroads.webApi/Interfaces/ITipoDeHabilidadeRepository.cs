using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoDeHabilidadeRepository
    {
        List<TipoDeHabilidade> Listar();


        TipoDeHabilidade BuscarPorId(int idTipoDeHabilidade);


        void Cadastrar(TipoDeHabilidade novoTipoDeHabilidade);

        void Atualizar(int idTipoDeHabilidade, TipoDeHabilidade TipoDeHabilidadeAtualizado);


        void Deletar(int idTipoDeHabilidade);


        //List<TipoDeHabilidade> ListarComClasse();
    }
}
