using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        FilmeRepository repositorio = new FilmeRepository();
        [HttpGet]
        public IEnumerable<FilmeDomain> ListarTodos()
        {
            return repositorio.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(repositorio.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            repositorio.Cadastrar(filme);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FilmeDomain filme)
        {
            try
            {
                if (repositorio.BuscarPorId(id) != null)
                {
                    filme.IdFilme = id;
                    repositorio.Atualizar(filme);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            repositorio.Deletar(repositorio.BuscarPorId(id));
            return Ok();
        }

    }
}
