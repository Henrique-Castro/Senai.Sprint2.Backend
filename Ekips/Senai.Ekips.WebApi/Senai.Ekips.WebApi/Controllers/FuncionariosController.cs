using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();

        /// <summary>
        /// This method gets a list of all Funcionarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            // pegar a permissao do token - HttpContext.User - c# get claim from jwt
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity == null)
            {
                throw new System.ArgumentException("Idk, you should talk to a programmer");
            }
                IEnumerable<Claim> claims = identity.Claims;
            // se a permissao for igual a adm
            if (identity.FindFirst(ClaimTypes.Role).Value.Equals("ADMINISTRADOR"))
            {
                return Ok(FuncionariosRepository.ListarTodos());
             }

            // senao
            return Ok(FuncionariosRepository.BuscarDadosFuncionario(Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value)));
                // faz um outro metodo no repositorio para listar somente um unico funcionario (pegar o id do token)
        }

        /// <summary>
        /// This method inserts a new employee into the database
        /// </summary>
        /// <param name="funcionario">Objetc Funcionario</param>
        /// <returns></returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                FuncionariosRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This method searches and updates the employee by it's Id
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="funcionarioModificado">Object Funcionario lacking the primary id</param>
        /// <returns></returns>
        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Funcionarios funcionarioModificado)
        {
            try
            {
                funcionarioModificado.IdFuncionario = id;
                FuncionariosRepository.Atualizar(funcionarioModificado);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Searches and deletes a employee by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles ="ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
            FuncionariosRepository.Deletar(id);
            return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("Este funcionário não existe ou não foi encontrado\n" + ex.Message);
            }
        }
    }
}