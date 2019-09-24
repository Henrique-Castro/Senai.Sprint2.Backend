using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;
using Senai.Optus.WebApi.ViewModels;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository UsuarioRepository = new UsuarioRepository();
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
            Usuarios usuarioEncontrado = UsuarioRepository.BuscarPorEmailSenha(dadosLogin);
            if(usuarioEncontrado == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos."});
            }
                var claims = new[]
                   {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("optus-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Optus.WebApi",
                    audience: "Optus.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds);

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