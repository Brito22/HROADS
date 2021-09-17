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
    public class PersonagemsController : ControllerBase
    {
        private IPersonagemRepository _PersonagemRepository { get; set; }


        public PersonagemsController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_PersonagemRepository.Listar());
        }


        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPorId(int idPersonagem)
        {
            return Ok(_PersonagemRepository.BuscarPorId(idPersonagem));
        }

        [Authorize(Roles = "Comum")]
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            _PersonagemRepository.Cadastrar(novoPersonagem);

            return StatusCode(201);
        }

        [Authorize(Roles = "Comum")]
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(int idPersonagem, Personagem PersonagemAtualizado)
        {
            _PersonagemRepository.Atualizar(idPersonagem, PersonagemAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "Comum")]
        [HttpDelete("{idPersonagem}")]
        public IActionResult Deletar(int idPersonagem)
        {
            _PersonagemRepository.Deletar(idPersonagem);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("Classe")]
        public IActionResult ListarComClasse()
        {
            return Ok(_PersonagemRepository.ListarComClasse());
        }
    }
}

