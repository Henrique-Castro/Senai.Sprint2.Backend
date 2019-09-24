using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissoesController : ControllerBase
    {
        PermissoesRepository PermissoesRepository = new PermissoesRepository();

        /// <summary>
        /// This method gets a list of all permissions
        /// </summary>
        /// <returns>List<Permissoes></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PermissoesRepository.Listar());
        }

        /// <summary>
        /// This method inserts a permission in database
        /// </summary>
        /// <param name="permissao">Permission object</param>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Permissoes permissao)
        {
            try
            {
                PermissoesRepository.Cadastrar(permissao);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}