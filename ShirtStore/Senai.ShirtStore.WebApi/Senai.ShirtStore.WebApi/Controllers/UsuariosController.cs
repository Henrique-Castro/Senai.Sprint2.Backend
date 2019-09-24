using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.Repositories;

namespace Senai.ShirtStore.WebApi.Controllers
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

        //[Authorize(Roles = "Gerente")]
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

        //[Authorize(Roles = "Gerente")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(IUsuariosRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios usuarioModificado)
        {
            try
            {
                usuarioModificado.UsuarioId = id;
                IUsuariosRepository.Atualizar(usuarioModificado);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                IUsuariosRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}