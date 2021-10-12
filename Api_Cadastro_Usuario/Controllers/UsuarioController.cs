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
        [HttpGet]
        [Route("LogedUser")]
        public IActionResult LogedUserIdentity()
        {
            return Ok(User.Identity.Name.ToString());
        }

        [Authorize]
        [HttpGet("TasksUsuario")]
        public IActionResult GetTasksToDo()
        {
            var usuarioLogado = _service.GetByEmail(User.Identity.Name);
            return Ok(_service.GetAllTasks(usuarioLogado.Codigo));
        }


        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutUsuarioModel(Guid id, UsuarioViewModel usuarioModel)
        {
            var user = usuarioModel.ViewModelToUsuario();
            user.Role = "User";
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
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteUsuarioModel()
        {
            var usuarioLogado = _service.GetByEmail(User.Identity.Name).Codigo;
            var usuarioModel = _service.Delet(usuarioLogado);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            // var token = HttpContext.Request.Headers[HeaderNames.Authorization].ToString();
            return NoContent();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(UsuarioLogin user)
        {
            var login = _service.Login(user);
            if (!login.IsValid)
                return NotFound(MostrarErros(login));
            var usuarioToken = _service.GetByEmail(user.Email);
            var token = SecurityService.TokenGenerator(usuarioToken);

            user.Senha = "";
            return Ok(new
            {
                Login = user.Email,
                Token = token
            });
        }


    }
}
