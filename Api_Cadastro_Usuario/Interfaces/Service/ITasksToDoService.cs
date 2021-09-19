using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface ITasksToDoService : IBaseService<TasksToDoModel>
    {
        public TasksToDoModel GetAllTasks(Guid id);
        public TasksViewModel Create(TasksViewModel model);
    }
}
