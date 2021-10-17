using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Cadastro_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksToDoController : ControllerPai
    {
        private readonly ITasksToDoService _service;

        public TasksToDoController(ITasksToDoService service)
        {
            _service = service;
        }

        // GET: api/TasksToDo
        //[HttpGet]
        //public IActionResult GetTasksToDo()
        //{
        //    return Ok(_service.GetAll());
        //}

        // GET: api/TasksToDo/5
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetTasksToDoModel()
        {
            var usuarioLogado = _service.GetByEmailUser(User.Identity.Name).Codigo;
            var tasksToDoModel = _service.GetAllTasks(usuarioLogado);
            return Ok(tasksToDoModel);
        }

        // POST: api/TasksToDo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult PostTasksToDoModel(TasksPostViewModel tasksToDoModel)
        {
            var usuarioLogado = _service.GetByEmailUser(User.Identity.Name).Codigo;
            var task = _service.Create(tasksToDoModel, usuarioLogado);

            if (!task.IsValid)
                return BadRequest(MostrarErros(task));
            return Ok(tasksToDoModel);
        }

        // DELETE: api/TasksToDo/5 
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        [HttpDelete("{id}")]
        public IActionResult DeleteTasksToDoModel(Guid id)
        {
            var task = _service.Delet(id);
            if (task == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
