using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.Repositories;
using Senai.ShirtStore.WebApi.ViewModels;

namespace Senai.ShirtStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUsuariosRepository IUsuariosRepository;

        public LoginController()
        {
            IUsuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuarios UsuarioEncontrado = IUsuariosRepository.BuscarPorEmailSenha(dadosLogin);

                var claims = new[] {
                      new Claim(JwtRegisteredClaimNames.Email, UsuarioEncontrado.Email),
                      new Claim(JwtRegisteredClaimNames.Jti, UsuarioEncontrado.UsuarioId.ToString()),
                      new Claim(ClaimTypes.Role, UsuarioEncontrado.Perfil)
                      ,new Claim("String" , UsuarioEncontrado.Empresa)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("shirtstore-chave-autenticação"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "ShirtStore.WebApi",
                        audience: "ShirtStore.WebApi",
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