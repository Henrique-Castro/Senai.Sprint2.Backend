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
    public class DepartamentosController : ControllerBase
    {
        DepartamentosRepository DepartamentosRepository = new DepartamentosRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(DepartamentosRepository.Listar());
        }
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                DepartamentosRepository.Cadastrar(departamento);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(DepartamentosRepository.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}