using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;
using Senai.AutoPecas.WebApi.ViewModels;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository IUsuariosRepository;
        private IFornecedoresRepository IFornecedoresRepository;


        public LoginController()
        {
            IUsuariosRepository = new UsuariosRepository();
            IFornecedoresRepository = new FornecedoresRepository();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuarios UsuarioBuscado = IUsuariosRepository.BuscarPorEmailSenha(dadosLogin);
                if (UsuarioBuscado == null)
                {
                    return NotFound();
                }
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, IFornecedoresRepository.BuscarPorIdUsuarioVinculado(UsuarioBuscado.UsuarioId).FornecedorId.ToString())
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("autopecas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "AutoPecas.WebApi",
                    audience: "AutoPecas.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}