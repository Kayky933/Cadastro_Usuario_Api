using Api_Cadastro_Usuario.Models;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface ITasksToDoRepository : IBaseRepository<TasksToDoModel>
    {
        public TasksToDoModel GetAllTasks(Guid id);
        public void Create(TasksToDoModel model);
    }
}
