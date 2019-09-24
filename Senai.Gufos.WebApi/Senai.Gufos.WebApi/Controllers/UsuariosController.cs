using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Repositories;
using Senai.Gufos.WebApi.ViewModels;

namespace Senai.Gufos.WebApi.Controllers
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
                if(UsuarioRepository.BuscarPorEmailESenha(dadosLogin) == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                }
                return Ok(new { mensagem = "Usuario encontrado com sucesso."});
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
    }
}