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
    public class AutorController : ControllerBase
    {
        AutorRepository repositorio = new AutorRepository();
        [HttpGet]
        public IEnumerable<AutorDomain> ListarGeneros()
        {
            return repositorio.ListarAutores();
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
        public IActionResult Cadastrar(AutorDomain autor)
        {
            Exception ex = new Exception();
            try
            {

                repositorio.Cadastrar(autor);

                return repositorio.BuscarPorId(autor.IdAutor) != null ? Ok() : throw new System.ArgumentException("Não foi possível cadastrar este autor", ex);
            }
            catch (ArgumentException)
            {
                return Conflict(ex.Message);
            }
        }


    }
}