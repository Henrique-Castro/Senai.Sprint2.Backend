using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class CategoriasController : ControllerBase
    {

        CategoriaRepository repository = new CategoriaRepository();
        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = repository.BuscarPorId(id);
            if(Categoria != null)
            {
                return Ok(Categoria);
            }
            return NotFound();
        }
        /// <summary>
        /// Cadastrar uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                repository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erooou!" + ex.Message });
            }
        }

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            repository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="categoriaModificada"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Categorias categoriaModificada)
        {
                Categorias CategoriaBuscada = repository.BuscarPorId(categoriaModificada.IdCategoria);

                if(CategoriaBuscada == null)
                {
                    return NotFound();
                }
                    repository.Atualizar(categoriaModificada);
                    return Ok();

        }
    }
}