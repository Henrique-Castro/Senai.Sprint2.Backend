using System;
using System.Collections.Generic;
using System.Linq;
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
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuariosRepository IUsuariosRepository;
        public UsuariosController()
        {
            IUsuariosRepository = new UsuariosRepository();
        }
        /*Disponibilizar um endpoint público para que seja apresentado os dados de todos os usuários, mas com um detalhe: a senha não deverá ser mostrada.
        GET /api/usuarios*/
        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(IUsuariosRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios novoUsuario)
        {
            try
            {
                IUsuariosRepository.Cadastrar(novoUsuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}