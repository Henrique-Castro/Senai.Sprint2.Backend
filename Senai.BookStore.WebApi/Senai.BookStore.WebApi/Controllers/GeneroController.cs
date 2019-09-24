using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        GeneroRepository repositorio = new GeneroRepository();
        [HttpGet]
        public IEnumerable<GeneroDomain> ListarGeneros()
        {
            return repositorio.ListarGeneros();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return repositorio.BuscarPorId(id) != null ? Ok(repositorio.BuscarPorId(id)) : throw new Exception();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain genero)
        {
            Exception ex = new Exception();
            try
            {
                
                repositorio.Cadastrar(genero);

                return repositorio.BuscarPorId(genero.Id) != null ? Ok() : throw new System.ArgumentException("Não foi possível cadastrar este gênero", ex);
            }
            catch(ArgumentException)
            {
                return Conflict(ex.Message);
            }
        }

        
    }
}