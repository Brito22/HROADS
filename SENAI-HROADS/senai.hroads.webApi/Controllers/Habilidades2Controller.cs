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
    public class Habilidades2Controller : ControllerBase
    {
        private IHabilidade2Repository _Habilidade2Repository { get; set; }


        public Habilidades2Controller()
        {
            _Habilidade2Repository = new Habilidade2Repository();
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_Habilidade2Repository.Listar());
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("{idHabilidade2}")]
        public IActionResult BuscarPorId(int idHabilidade2)
        {
            return Ok(_Habilidade2Repository.BuscarPorId(idHabilidade2));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Habilidade2 novoHabilidade2)
        {
            _Habilidade2Repository.Cadastrar(novoHabilidade2);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{idHabilidade2}")]
        public IActionResult Atualizar(int idHabilidade2, Habilidade2 Habilidade2Atualizado)
        {
            _Habilidade2Repository.Atualizar(idHabilidade2, Habilidade2Atualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{idHabilidade2}")]
        public IActionResult Deletar(int idHabilidade2)
        {
            _Habilidade2Repository.Deletar(idHabilidade2);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("Habilidade")]
        public IActionResult ListarComTipoHabilidade()
        {
            return Ok(_Habilidade2Repository.ListarComTipoHabilidade());
        }
    }
}
