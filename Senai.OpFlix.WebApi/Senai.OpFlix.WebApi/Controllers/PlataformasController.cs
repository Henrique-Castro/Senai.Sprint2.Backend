using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PlataformasController : ControllerBase
    {
        IPlataformasRepository IPlataformasRepository;

        public PlataformasController()
        {
            IPlataformasRepository = new PlataformasRepository();
        }

        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas novaPlataforma)
        {
            try
            {
                IPlataformasRepository.Cadastrar(novaPlataforma);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Plataformas plataformaModificada)
        {
            try
            {
                plataformaModificada.IdPlataforma = id;
                IPlataformasRepository.Atualizar(plataformaModificada);
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
                return Ok(IPlataformasRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}