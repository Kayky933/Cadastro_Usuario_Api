using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Service
{
    public class TasksToDoService : ITasksToDoService
    {
        private readonly ITasksToDoRepository _repository;
        public TasksToDoService(ITasksToDoRepository repository)
        {
            _repository = repository;
        }
        public ValidationResult Create(TasksViewModel model)
        {
            var validation = new TaskValidationModel(_repository).Validate(model);
            var convertModel = model.ViewModelToTasks();
            if (!validation.IsValid)
                return validation;

            _repository.Create(convertModel);
            return validation;
        }
        public UsuarioModel GetOneUsuario(Guid codigo)
        {
            var response = _repository.GetOneUsuario(codigo);
            if (response == null)
                return null;
            return response;
        }


        public TasksToDoModel Delet(Guid model)
        {
            var modelDelet = _repository.GetOne(model);
            if (modelDelet == null)
                return null;
            _repository.Delet(modelDelet);
            return modelDelet;
        }

        public IEnumerable<TasksToDoModel> GetAll()
        {
            return _repository.GetAll();
        }

        public TasksToDoModel GetAllTasks(Guid id)
        {
            return _repository.GetAllTasks(id);
        }

        public TasksToDoModel GetOne(Guid codigo)
        {
            return _repository.GetOne(codigo);
        }
    }
}
