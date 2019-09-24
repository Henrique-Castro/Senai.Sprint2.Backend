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
    public class EmpresasController : ControllerBase
    {
        IEmpresasRepository IEmpresasRepository;

        public EmpresasController()
        {
            IEmpresasRepository = new EmpresasRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(IEmpresasRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(IEmpresasRepository.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public IActionResult Cadastrar(Empresas novaEmpresa)
        {
            try
            {
                IEmpresasRepository.Cadastrar(novaEmpresa);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Empresas empresaModificada)
        {
            try
            {
                empresaModificada.EmpresaId = id;
                IEmpresasRepository.Atualizar(empresaModificada);
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
                if(IEmpresasRepository.BuscarPorId(id) == null)
                {
                    return NotFound();
                }
                IEmpresasRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}