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
    [ApiController]
    public class TamanhosController : ControllerBase
    {
        ITamanhosRepository ITamanhosRepository;
        IEmpresasRepository IEmpresasRepository;

        public TamanhosController()
        {
            IEmpresasRepository = new EmpresasRepository();
            ITamanhosRepository = new TamanhosRepository();
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ITamanhosRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(ITamanhosRepository.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public IActionResult Cadastrar(Tamanhos novoTamanho)
        {
            try
            {
                ITamanhosRepository.Cadastrar(novoTamanho);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Gerente")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tamanhos tamanhoModificado)
        {
            try
            {
                tamanhoModificado.TamanhoId = id;
                ITamanhosRepository.Atualizar(tamanhoModificado);
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
                ITamanhosRepository.Deletar(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}