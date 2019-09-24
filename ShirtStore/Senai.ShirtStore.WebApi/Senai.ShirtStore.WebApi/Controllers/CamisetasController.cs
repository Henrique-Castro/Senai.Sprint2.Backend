using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CamisetasController : ControllerBase
    {
        ICamisetasRepository ICamisetasRepository;

        public CamisetasController()
        {
            ICamisetasRepository = new CamisetasRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ICamisetasRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(ICamisetasRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Camisetas novaCamiseta)
        {
            try
            {
                var usuario = HttpContext.User;
                string empresa = usuario.Claims.FirstOrDefault(x => x.Type.Equals("String")).Value;
                novaCamiseta.Marca = empresa;

                ICamisetasRepository.Cadastrar(novaCamiseta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Camisetas camisetaModificada)
        {
            try
            {
                camisetaModificada.CamisetaId = id;
                ICamisetasRepository.Atualizar(camisetaModificada);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var usuario = HttpContext.User;
                string empresa = usuario.Claims.FirstOrDefault(x => x.Type.Equals("String")).Value;
                if (ICamisetasRepository.BuscarPorId(id).Marca.Equals(empresa))
                {
                    ICamisetasRepository.Deletar(id);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}