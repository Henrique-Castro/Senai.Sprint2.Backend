using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();
        EstiloRepository EstiloRepository = new EstiloRepository();
        /// <summary>
        /// Listar todos os estilos
        /// </summary>
        /// <returns>Lista de estilos</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstiloRepository.Listar());
        }

        /// <summary>
        /// Cadastrar estilo
        /// </summary>
        /// <param name="novoEstilo"> Estilo </param>
        /// <returns></returns>
        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos novoEstilo)
        {
            try
            {
                EstiloRepository.Cadastrar(novoEstilo);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="estiloModificado"> Novo estilo</param>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estiloModificado)
        {
            try
            {
                EstiloRepository.Atualizar(estiloModificado);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletar estilo
        /// </summary>
        /// <param name="id"> id</param>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("buscar/{id}/artistas")]
        public IActionResult BuscarArtistasPorIdEstilo(int id)
        {
            return Ok(ArtistaRepository.BuscarArtistasPorIdEstilo(id));
        }
        [Authorize]
        [HttpGet("quantidade")]
        public IActionResult QuantidadeEstilos()
        {
            return Ok(EstiloRepository.Listar().Count());
        }

    }
}
