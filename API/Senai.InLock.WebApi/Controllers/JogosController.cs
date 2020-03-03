using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{

    [Produces("application/json")]


    [Route("api/[controller]")]


    [ApiController]
    [Authorize]
    public class JogosController : Controller
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do Estudio é obrigatório!");
            }

            _jogosRepository.Cadastrar(novoJogo);


            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }

    }
}
