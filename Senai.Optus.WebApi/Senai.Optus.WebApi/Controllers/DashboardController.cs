using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();
        EstiloRepository EstiloRepository = new EstiloRepository();
        [HttpGet]
        public IActionResult ListarArtistasEstilos()
        {
            return Ok(ArtistaRepository.Listar().Count() + ArtistaRepository.Listar().Count());
        }
    }
}