using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Cadastro_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerPai
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
        [Authorize]
        [HttpGet("TasksUsuario/{id}")]
        public IActionResult GetTasksToDo(Guid id)
        {
            return Ok(_service.GetAllTasks(id));
        }


        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutUsuarioModel(Guid id, UsuarioViewModel usuarioModel)
        {
            var user = usuarioModel.ViewModelToUsuario();

            var response = _service.Put(id, user);
            if (!response.IsValid)
                return BadRequest(MostrarErros(response));
            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUsuarioModel(UsuarioViewModel usuarioModel)
        {

            var response = _service.Create(usuarioModel);
            if (!response.IsValid)
                return BadRequest(MostrarErros(response));

            return Ok(usuarioModel);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteUsuarioModel(Guid id)
        {
            var usuarioModel = _service.Delet(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UsuarioLogin user)
        {
            var login = _service.Login(user);
            if (!login.IsValid)
                return NotFound(MostrarErros(login));
            var token = SecurityService.TokenGenerator(user);
            user.Senha = "";

            return Ok(new
            {
                Login = user,
                Token = token
            });
        }


    }
}
