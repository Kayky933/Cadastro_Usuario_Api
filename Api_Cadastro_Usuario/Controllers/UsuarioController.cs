using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.POCO;
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

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
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
        public IActionResult PutUsuarioModel(Guid id, UsuarioViewModel usuarioModel)
        {
            var user = usuarioModel.ViewModelToUsuario();
            user.Codigo = id;
            _service.GetContext().Update(user).State = EntityState.Modified;

            var response = _service.Put(id, user);
            if (response == null)
                return BadRequest();
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
