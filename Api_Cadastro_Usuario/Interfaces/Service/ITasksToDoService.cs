using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface ITasksToDoService : IBaseService<TasksToDoModel>
    {
        public UsuarioModel GetOneUsuario(Guid id);
        public UsuarioModel GetByEmailUser(string email);
        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id);
        public ValidationResult Create(TasksPostViewModel model, Guid id);
    }
}
