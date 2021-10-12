using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using FluentValidation.Results;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface ITasksToDoService : IBaseService<TasksToDoModel>
    {
        public UsuarioModel GetOneUsuario(Guid id);
        public UsuarioModel GetByEmailUser(string email);
        public TasksToDoModel GetAllTasks(Guid id);
        public ValidationResult Create(TasksPostViewModel model, Guid id);
    }
}
