using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using Senai.Ekips.WebApi.ViewModels;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuariosRepository UsuariosRepository = new UsuariosRepository();

        /// <summary>
        /// This method tries to get the user object in the database
        /// </summary>
        /// <param name="dadosLogin">LoginViewModel with Email and Senha</param>
        /// <returns>Authorization token</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuarios UsuarioBuscado = UsuariosRepository.Login(dadosLogin);
                if(UsuarioBuscado == null)
                {
                    return NotFound();
                }
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    UsuarioBuscado.IdPermissao == 1?
                    new Claim(ClaimTypes.Role, "ADMINISTRADOR") : null
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ekips-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Ekips.WebApi",
                    audience: "Ekips.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
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