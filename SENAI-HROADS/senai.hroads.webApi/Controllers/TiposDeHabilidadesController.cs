using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TiposDeHabilidadesController : ControllerBase
    {
        private ITipoDeHabilidadeRepository _TipoDeHabilidadeRepository { get; set; }


        public TiposDeHabilidadesController()
        {
            _TipoDeHabilidadeRepository = new TipoDeHabilidadeRepository();
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TipoDeHabilidadeRepository.Listar());
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("{idTipoDeHabilidade}")]
        public IActionResult BuscarPorId(int idTipoDeHabilidade)
        {
            return Ok(_TipoDeHabilidadeRepository.BuscarPorId(idTipoDeHabilidade));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(TipoDeHabilidade novoTipoDeHabilidade)
        {
            _TipoDeHabilidadeRepository.Cadastrar(novoTipoDeHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{idTipoDeHabilidade}")]
        public IActionResult Atualizar(int idTipoDeHabilidade, TipoDeHabilidade TipoDeHabilidadeAtualizado)
        {
            _TipoDeHabilidadeRepository.Atualizar(idTipoDeHabilidade, TipoDeHabilidadeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{idTipoDeHabilidade}")]
        public IActionResult Deletar(int idTipoDeHabilidade)
        {
            _TipoDeHabilidadeRepository.Deletar(idTipoDeHabilidade);

            return StatusCode(204);
        }
    }
}
