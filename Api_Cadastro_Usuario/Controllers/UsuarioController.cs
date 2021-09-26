using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;

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
            if (login == null)
                return NotFound();
            var token = TokenService.TokenGenerator(login);
            login.Senha = "";
            return Ok(new
            {
                Login = login,
                Token = token
            });
        }


    }
}
