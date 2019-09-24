using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        IPecasRepository IPecasRepository;

        public PecasController()
        {
            IPecasRepository = new PecasRepository();
        }

        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(IPecasRepository.ListarTodas());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{codigo}")]
        public IActionResult BuscarPorCodigo(int codigo)
        {
            try
            {
                return Ok(IPecasRepository.BuscarPecaPorCodigo(codigo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{codigo}")]
        public IActionResult Atualizar(int codigo, Pecas pecaModificada)
        {
            try
            {
                int IdFornecedor = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                Pecas pecaEncontrada = IPecasRepository.BuscarPecaPorCodigo(codigo);
                if(pecaEncontrada.FornecedorId != IdFornecedor)
                {
                    throw new Exception(message: "Esta peça não é sua, pilantra.");
                }
                else
                {
                IPecasRepository.Atualizar(pecaModificada);
                return Ok();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public IActionResult Cadastrar(Pecas novaPeca)
        {
            try
            {
                int idFornecedor = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                novaPeca.FornecedorId = idFornecedor;
                IPecasRepository.Cadastrar(novaPeca);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /*Disponibilizar um endpoint para que seja mostrado o valor de ganho que a autopeças irá obter calculando
         * o preço de venda sob o preço de custo. Mostrar a porcentagem e um outro campo mostrando a diferença em reais entre um e outro.*/
        
        [HttpGet("ganhos")]
        public IActionResult ValorGanhos()
        {
            try
            {
                return Ok(IPecasRepository.ValorGanhos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /*Disponibilizar um endpoint para que ao enviar a quantidade de itens e o id da peça, seja calculado o valor total e este valor seja retornado.
        POST /api/pecas/calcular*/
        
        [HttpPost("calcular")]
        public IActionResult Calcular(int codigo , int quantidade)
        {
            try
            {
                return Ok(IPecasRepository.CalcularPedido(codigo , quantidade));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        

        

    }
}