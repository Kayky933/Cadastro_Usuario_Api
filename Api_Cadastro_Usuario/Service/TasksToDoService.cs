using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Service
{
    public class TasksToDoService : ITasksToDoService
    {
        private readonly ITasksToDoRepository _repository;
        private readonly IMapper _mapper;
        public TasksToDoService(ITasksToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public ValidationResult Create(TasksPostViewModel model, Guid id)
        {
            var validation = new TaskValidationModel().Validate(model);

            if (!validation.IsValid)
                return validation;

            var convertModel = _mapper.Map<TasksToDoModel>(model);
            convertModel.Id_Usuario = id;

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

        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id)
        {
            return _repository.GetAllTasks(id);
        }

        public TasksToDoModel GetOne(Guid codigo)
        {
            return _repository.GetOne(codigo);
        }

        public UsuarioModel GetByEmailUser(string email)
        {
            return _repository.GetByEmailUser(email);
        }

    }
}
