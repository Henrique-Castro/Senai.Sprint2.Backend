using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            return funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioNovo)
        {
            funcionarioRepository.Cadastrar(funcionarioNovo);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(FuncionarioDomain funcionarioAlterado)
        {
            funcionarioRepository.Atualizar(funcionarioAlterado);
            return Ok();
        }

        [HttpGet("buscar/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(funcionarioRepository.BuscarPorId(id));
        }
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(funcionarioRepository.BuscarPorNome(nome));
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(funcionarioRepository.BuscarPorId(id));
            return Ok();
        }
    }
}
