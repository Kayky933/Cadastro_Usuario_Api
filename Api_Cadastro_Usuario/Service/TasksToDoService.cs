using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
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
        public TasksViewModel Create(TasksViewModel model)
        {
            var convertModel = model.ViewModelToTasks();
            _repository.Create(convertModel);
            return model;
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
