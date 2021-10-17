using Api_Cadastro_Usuario.Models;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface ITasksToDoRepository : IBaseRepository<TasksToDoModel>
    {
        public UsuarioModel GetOneUsuario(Guid id);
        public UsuarioModel GetByEmailUser(string email);
        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id);
        public void Create(TasksToDoModel model);
    }
}
