using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
                return NotFound("E-mail ou senha inválidos!");

            // return Ok(usuarioBuscado);

            // Define os dados que serão fornecidos no token - Payload
            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Titulo.ToString()),

            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HROADS-CHAVE-AUTENFICACAO"));

            // Define as credenciais do token - signature
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Composição do token
            var meuToken = new JwtSecurityToken(
                    issuer: "HROADS.webAPI",                // emissor do token
                    audience: "HROADS.webAPI",                // destinatário do token
                    claims: minhasClaims,                   // dados definidos acima (linha 39)
                    expires: DateTime.Now.AddMinutes(50),    // tempo de expiração do token
                    signingCredentials: creds                   // credenciais do token
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(meuToken)
            });
        }
    }
}

