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
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();


        /// <summary>
        /// Listar todos os artistas
        /// </summary>
        /// <returns>Lista de artistas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }

        /// <summary>
        /// Cadastrar artista
        /// </summary>
        /// <param name="novoArtista"> Artista </param>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Artistas novoArtista)
        {
            try
            {
                ArtistaRepository.Cadastrar(novoArtista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="artistaModificado"> Novo artista</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Artistas artistaModificado)
        {
            try
            {
                ArtistaRepository.Atualizar(artistaModificado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deletar estilo
        /// </summary>
        /// <param name="id"> id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            ArtistaRepository.Deletar(id);
            return Ok();
        }
    }
}