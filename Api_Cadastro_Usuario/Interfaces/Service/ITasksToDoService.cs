using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using FluentValidation.Results;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface ITasksToDoService : IBaseService<TasksToDoModel>
    {
        public UsuarioModel GetOneUsuario(Guid id);
        public TasksToDoModel GetAllTasks(Guid id);
        public ValidationResult Create(TasksViewModel model);
    }
}
