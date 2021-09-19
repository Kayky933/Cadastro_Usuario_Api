using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_Cadastro_Usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksToDoController : ControllerBase
    {
        private readonly ITasksToDoService _context;

        public TasksToDoController(ITasksToDoService context)
        {
            _context = context;
        }

        // GET: api/TasksToDo
        //[Authorize]
        [HttpGet]
        public IActionResult GetTasksToDo()
        {
            return Ok(_context.GetAll());
        }
        //[Authorize]
       

        // GET: api/TasksToDo/5
        //[Authorize]
        [HttpGet("{id}")]
        public IActionResult GetTasksToDoModel(Guid id)
        {
            var tasksToDoModel = _context.GetOne(id);
            return Ok(tasksToDoModel);
        }

        // POST: api/TasksToDo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Authorize]
        [HttpPost]
        public IActionResult PostTasksToDoModel(TasksViewModel tasksToDoModel)
        {
            var task = _context.Create(tasksToDoModel);
            return Ok(task);
        }

        // DELETE: api/TasksToDo/5        
        //[Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteTasksToDoModel(Guid id)
        {
            var task = _context.Delet(id);
            if (task == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
