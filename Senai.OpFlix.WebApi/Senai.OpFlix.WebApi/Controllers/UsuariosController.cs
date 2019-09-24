using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuariosRepository IUsuariosRepository;

        public UsuariosController()
        {
            IUsuariosRepository = new UsuariosRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios novoUsuario)
        {
            try
            {
                IUsuariosRepository.Cadastrar(novoUsuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuarios UsuarioBuscado = IUsuariosRepository.BuscarPorEmailSenha(dadosLogin);

                if(UsuarioBuscado == null)
                {
                    return NotFound();
                }

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email,UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.Tipo)
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "OpFlix.WebApi",
                        audience: "OpFlix.WebApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}