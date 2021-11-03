using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("Get_All_Users")]
        public IActionResult GetUsuarioModel()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("Get_Tasks_Usuario")]
        public IActionResult GetTasksToDo()
        {
            var usuarioEmail = User.Identity.Name;
            var currentToken = TokenService.GetAllTokensByEmail(usuarioEmail);
            var email = TokenService.GetEmailByTokens(currentToken);
            if (email == null)
                return NotFound("Usuario não logado!");

            var token = TokenService.GetAllTokensByEmail(email);
            if (token == null)
                return NotFound("Usuario não logado!");
            var usuarioLogado = _service.GetByEmail(email);
            var tasks = _service.GetAllTasks(usuarioLogado.Codigo);
            return Ok(tasks);
        }


        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("Put_Usuario/{id}")]
        public IActionResult PutUsuarioModel(UsuarioViewModel usuarioModel)
        {
            var currentToken = TokenService.GetAllTokensByEmail(usuarioModel.Email);
            var token = TokenService.GetAllTokensByEmail(usuarioModel.Email);
            if (token == null)
                return NotFound("Usuario não logado!");

            var user = TokenService.GetEmailByTokens(currentToken);
            if (user == null)
                return NotFound("Usuario não logado!");

            if (usuarioModel.Email != user)
                return BadRequest("Usuario incorreto!");

            var response = _service.Put(usuarioModel);
            if (!response.IsValid)
                return BadRequest(MostrarErros(response));
            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create_Usuario")]
        public IActionResult PostUsuarioModel(UsuarioViewModel usuarioModel)
        {
            var token = TokenService.GetAllTokensByEmail(usuarioModel.Email);
            if (token != null)
                return BadRequest("Usuario Já esta logado!");

            var response = _service.Create(usuarioModel);
            if (!response.IsValid)
                return BadRequest(MostrarErros(response));

            return Ok(usuarioModel);
        }

        // DELETE: api/Usuario/5
        [Authorize]
        [HttpDelete("Dele_Usuario")]
        public IActionResult DeleteUsuarioModel(UsuarioLogin usuario)
        {
            var testeLoginUsuario = _service.Login(usuario);

            if (testeLoginUsuario == null)
                return BadRequest("Usuario incorreto!");

            var token = TokenService.GetAllTokensByEmail(usuario.Email);
            if (token == null)
                return NotFound("Usuario não logado!");

            var usuarioDelet = _service.GetByEmail(usuario.Email).Codigo;
            var usuarioModel = _service.Delet(usuarioDelet);
            if (usuarioModel == null)
                return NotFound();

            return NoContent();
        }

        [HttpPost("Login")]
        public IActionResult Login(UsuarioLogin user)
        {
            var usuarioToken = _service.GetByEmail(user.Email);
            var tokenVerification = TokenService.GetAllTokensByEmail(user.Email);
            if (tokenVerification != null)
                return BadRequest("Usuario já logado!");

            var login = _service.Login(user);
            if (!login.IsValid)
                return NotFound(MostrarErros(login));

            var newTokens = TokenService.LoginSaveTokens(usuarioToken);

            user.Senha = "";
            return Ok(new
            {
                Login = user.Email,
                Token = newTokens.Token,
                refreshToken = newTokens.RefreshToken
            });

        }

        [Authorize]
        [HttpPost("Refresh_Token")]
        public IActionResult Refresh(string refreshToken)
        {
            var email = TokenService.GetAllEmailsByTokens(refreshToken);
            var tokensCurrent = TokenService.GetToken(email);
            if (email == null)
                return NotFound("Usuario não logado!");

            var newTokenGenerateds = TokenService.RefreshGenerator(tokensCurrent, refreshToken, email);

            if (newTokenGenerateds == null)
                return BadRequest("Invalid refresh");

            return new ObjectResult(new
            {
                token = newTokenGenerateds.Token,
                refreshToken = newTokenGenerateds.RefreshToken
            });

        }

        [Authorize]
        [HttpPost("LogOut")]
        public IActionResult LogOut()
        {
            string usuarioLogado = User.Identity.Name.ToString();
            if (usuarioLogado == null)
                return NotFound("Usuario não logado!");

            var token = TokenService.GetAllTokensByEmail(usuarioLogado);
            var userEmail = TokenService.GetEmailByTokens(token);
            var allTokens = TokenService.GetAllTokensByEmail(userEmail);

            if (allTokens == null)
                return NotFound("Sem autorização!");


            TokenService.DeletAllTokens(userEmail);

            return Ok("Usuario deslogado com sucesso!");
        }
    }
}
