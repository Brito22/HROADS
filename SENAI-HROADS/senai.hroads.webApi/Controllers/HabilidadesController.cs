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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }


        public HabilidadesController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_HabilidadeRepository.Listar());
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarPorId(int idHabilidade)
        {
            return Ok(_HabilidadeRepository.BuscarPorId(idHabilidade));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novoHabilidade)
        {
            _HabilidadeRepository.Cadastrar(novoHabilidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{idHabilidade}")]
        public IActionResult Atualizar(int idHabilidade, Habilidade HabilidadeAtualizado)
        {
            _HabilidadeRepository.Atualizar(idHabilidade, HabilidadeAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{idHabilidade}")]
        public IActionResult Deletar(int idHabilidade)
        {
            _HabilidadeRepository.Deletar(idHabilidade);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("TipoDeHabilidade")]
        public IActionResult ListarComTipoHabilidade()
        {
            return Ok(_HabilidadeRepository.ListarComTipoHabilidade());
        }
    }
}

