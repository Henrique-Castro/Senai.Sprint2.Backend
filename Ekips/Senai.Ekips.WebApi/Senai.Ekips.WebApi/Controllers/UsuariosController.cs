using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuariosRepository UsuariosRepository = new UsuariosRepository();

        /// <summary>
        /// This method inserts new users in database
        /// </summary>
        /// <param name="usuario">Object usuario</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuariosRepository.Cadastrar(usuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This method gets the list of all users
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuariosRepository.Listar());
        }
    }
}