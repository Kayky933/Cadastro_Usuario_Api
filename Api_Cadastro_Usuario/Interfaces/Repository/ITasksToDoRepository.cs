using Api_Cadastro_Usuario.Models;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface ITasksToDoRepository : IBaseRepository<TasksToDoModel>
    {
        public UsuarioModel GetOneUsuario(Guid id);
        public TasksToDoModel GetAllTasks(Guid id);
        public void Create(TasksToDoModel model);
    }
}
