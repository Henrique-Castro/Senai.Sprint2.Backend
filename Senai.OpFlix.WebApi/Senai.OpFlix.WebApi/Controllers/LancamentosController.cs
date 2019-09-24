using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {

        ILancamentosRepository ILancamentosRepository;
        ICategoriasRepository ICategoriasRepository;
        IPlataformasRepository IPlataformasRepository;


        public LancamentosController()
        {
            ILancamentosRepository = new LancamentosRepository();
            ICategoriasRepository = new CategoriasRepository();
            IPlataformasRepository = new PlataformasRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos novoLancamento)
        {
            try
            {
                ILancamentosRepository.Cadastrar(novoLancamento);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("Visiveis")]
        public IActionResult Listarvisiveis()
        {
            try
            {
                return Ok(ILancamentosRepository.ListarVisiveis());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("Todos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(ILancamentosRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lancamentos lancamentoModificado)
        {
            try
            {
                lancamentoModificado.IdLancamento = id;
                ILancamentosRepository.Atualizar(lancamentoModificado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                ILancamentosRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{titulo}")]
        public IActionResult Deletar(string titulo)
        {
            try
            {
                ILancamentosRepository.Deletar(titulo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Favoritar")]
        public IActionResult Favoritar(int idLancamentoFavoritado)
        {
            try
            {
                int IdUsuarioLogado = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti));
                ILancamentosRepository.Favoritar(IdUsuarioLogado, idLancamentoFavoritado);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("OrdenarPorData")]
        public IActionResult OrdenarPorData()
        {
            try
            {
                return Ok(ILancamentosRepository.ListarPorDataLancamento());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("OrdenarPorCategoria")]
        public IActionResult OrdenarPorCategoria()
        {
            try
            {
                return Ok(ILancamentosRepository.ListarPorCategoria());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("OrdenarPorEstreiaECategoria")]
        public IActionResult OrdenarPorEstreiaECategoria()
        {
            try
            {
                return Ok(ILancamentosRepository.ListarPorEstreiaECategoria());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarFavoritos/{id}")]
        public IActionResult ListarFavoritos(int idUsuario)
        {
            try
            {
                return Ok(ILancamentosRepository.ListarFavoritos(idUsuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ListarPorPlataforma/{nomePlataforma}")]
        public IActionResult ListarPorPlataforma(string nomePlataforma)
        {
            try
            {
                Plataformas plataformaEncontrada = IPlataformasRepository.BuscarPorNome(nomePlataforma);
                return Ok(ILancamentosRepository.ListarPorPlataformas(plataformaEncontrada.IdPlataforma));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}