using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        ICategoriasRepository ICategoriasRepository;

        public CategoriasController()
        {
            ICategoriasRepository = new CategoriasRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias novaCategoria)
        {
            try
            {
                //HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value));
                ICategoriasRepository.Cadastrar(novaCategoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ICategoriasRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorias categoriaModificada)
        {
            try
            {
                categoriaModificada.IdCategoria = id;
                ICategoriasRepository.Atualizar(categoriaModificada);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ICategoriasRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{titulo}")]
        public IActionResult Deletar(string titulo)
        {
            try
            {
                ICategoriasRepository.Deletar(titulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Favoritar")]
        public IActionResult Favoritar(int idCategoria)
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                ICategoriasRepository.Favoritar(idUsuario, idCategoria);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("ListarFavoritos/{id}")]
        public IActionResult ListarFavoritos(int idUsuario)
        {
            try
            {
                return Ok(ICategoriasRepository.ListarFavoritos(idUsuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}