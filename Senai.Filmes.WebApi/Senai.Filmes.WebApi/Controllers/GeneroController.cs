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
    public class GeneroController : ControllerBase
    {
        GeneroRepository repositorio = new GeneroRepository();
        [HttpGet]
        public IEnumerable<GeneroDomain> ListarTodos()
        {
            return Utils.Repeticoes.GeneroRepository.Listar();
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(Utils.Repeticoes.GeneroRepository.BuscarPorId(id));
        }
        [HttpGet("{id}/filmes")]
        public IEnumerable<FilmeDomain> ListarFilmesPorGenero(int id)
        {
            return repositorio.ListarFilmes(id);
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            Utils.Repeticoes.GeneroRepository.Cadastrar(genero);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, GeneroDomain genero)
        {
            try
            {
                if(Utils.Repeticoes.GeneroRepository.BuscarPorId(id) != null)
                {
                    genero.IdGenero = id;
                    Utils.Repeticoes.GeneroRepository.Atualizar(genero);
                    return Ok();
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            Utils.Repeticoes.GeneroRepository.Deletar(id);
            return Ok();
        }   
    }
}
