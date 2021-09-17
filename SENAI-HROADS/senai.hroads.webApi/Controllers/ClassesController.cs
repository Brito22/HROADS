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
    public class ClassesController : ControllerBase
    {
     
        private IClasseRepository _classeRepository { get; set; }

      
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.Listar());
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Classe novoClasse)
        {
            _classeRepository.Cadastrar(novoClasse);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar(int idClasse, Classe ClasseAtualizado)
        {
            _classeRepository.Atualizar(idClasse, ClasseAtualizado);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{idClasse}")]
        public IActionResult Deletar(int idClasse)
        {
            _classeRepository.Deletar(idClasse);

            return StatusCode(204);
        }

        [Authorize(Roles = "Administrador, Comum")]
        [HttpGet("Habilidade")]
        public IActionResult ListarComHabilidades()
        {
            return Ok(_classeRepository.ListarComHabilidades());
        }
    }
}
