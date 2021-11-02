using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
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
        [HttpGet]
        [Route("Token")]
        public IActionResult ActualToken()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            return Ok(token.ToString());
        }

        [Authorize]
        [HttpGet("TasksUsuario")]
        public IActionResult GetTasksToDo()
        {
            var user = _service.GetByEmail(User.Identity.Name);
            var token = SecurityService.GetToken(user.Email);
            if (token == null || user == null)
                return NotFound("Usuario não logado!");

            var tasks = _service.GetAllTasks(user.Codigo);
            return Ok(tasks);
        }


        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutUsuarioModel(Guid id, UsuarioViewModel usuarioModel)
        {
            var user = _service.GetByEmail(User.Identity.Name);
            var token = SecurityService.GetToken(user.Email);
            if (token == null || user == null)
                return NotFound("Usuario não logado!");

            var response = _service.Put(usuarioModel);
            if (!response.IsValid)
                return BadRequest(MostrarErros(response));
            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUsuarioModel(UsuarioViewModel usuarioModel)
        {
            var user = _service.GetByEmail(User.Identity.Name);
            var token = SecurityService.GetToken(user.Email);
            if (token != null)
                return BadRequest("Usuario Já esta logado!");

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
            var user = _service.GetByEmail(User.Identity.Name);
            var token = SecurityService.GetToken(user.Email);
            if (token == null || user == null)
                return NotFound("Usuario não logado!");

            var usuarioModel = _service.Delet(user.Codigo);
            if (usuarioModel == null)
                return NotFound();


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
            var refreshToken = SecurityService.GenerateRefreshToken();

            SecurityService.SaveRefreshToken(usuarioToken.Email, refreshToken);
            SecurityService.SaveToken(usuarioToken.Email, token);


            user.Senha = "";
            return Ok(new
            {
                Login = user.Email,
                Token = token,
                refreshToken = refreshToken
            });
        }

        [Authorize]
        [HttpPost("RefreshToken")]
        public IActionResult Refresh(string token, string refreshToken)
        {
            var user = _service.GetByEmail(User.Identity.Name);
            if (user == null)
                return NotFound("Usuario não logado!");

            var userEmail = _service.GetByEmail(User.Identity.Name);
            var principal = SecurityService.GetPrincipalFromExpiresToken(token);
            var saveRefreshToken = SecurityService.GetRefreshToken(userEmail.Email);

            if (saveRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh");

            var newRefreshToken = SecurityService.GenerateRefreshToken();
            var newJwtToken = SecurityService.TokenGenerator(principal.Claims);
            SecurityService.DeletToken(userEmail.Email, refreshToken);
            SecurityService.SaveToken(userEmail.Email, newRefreshToken);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });

        }

        [Authorize]
        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            var user = _service.GetByEmail(User.Identity.Name);
            if (user == null)
                return NotFound("Usuario não logado!");
            var actualToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            SecurityService.DeletToken(user.Email, actualToken);
            return Ok("Usuario deslogado com sucesso!");
        }

    }
}
