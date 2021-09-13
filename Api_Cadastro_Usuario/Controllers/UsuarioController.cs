using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_Cadastro_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly Api_Cadastro_UsuarioContext _context;

        public UsuarioController(IUsuarioService service, Api_Cadastro_UsuarioContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public IActionResult GetUsuarioModel()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public IActionResult GetUsuarioModel(Guid id)
        {
            var usuarioModel = _service.GetOne(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return Ok(usuarioModel);
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUsuarioModel(Guid id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetOne(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUsuarioModel(UsuarioViewModel usuarioModel)
        {
            var newUser = _service.Create(usuarioModel);
            if (newUser == null)
                return StatusCode(400, "Ops, Pelo visto ha alguma informação que não foi preenchida corretamente");

            return StatusCode(201, "Usuario criado com sucesso!");
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuarioModel(Guid id)
        {
            var usuarioModel = _service.Delet(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
