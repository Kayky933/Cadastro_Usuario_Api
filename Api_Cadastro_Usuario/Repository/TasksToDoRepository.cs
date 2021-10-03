using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api_Cadastro_Usuario.Repository
{
    public class TasksToDoRepository : ITasksToDoRepository
    {
        private readonly Api_Cadastro_UsuarioContext _context;
        public TasksToDoRepository(Api_Cadastro_UsuarioContext context)
        {
            _context = context;
        }

        public void Create(TasksToDoModel model)
        {
            _context.TasksToDo.Add(model);
            SaveChangesDb();
        }


        public void Delet(TasksToDoModel model)
        {
            _context.TasksToDo.Remove(model);
            SaveChangesDb();
        }

        public IEnumerable<TasksToDoModel> GetAll()
        {
            return _context.TasksToDo.ToList();
        }

        public TasksToDoModel GetAllTasks(Guid id)
        {
            return _context.TasksToDo.Where(a => a.Id_Usuario == id).FirstOrDefault();
        }

        public TasksToDoModel GetOne(Guid codigo)
        {
            return _context.TasksToDo.Where(a => a.Id == codigo).FirstOrDefault();
        }

        public UsuarioModel GetOneUsuario(Guid id)
        {
            return _context.UsuarioModel.Where(a => a.Codigo == id).FirstOrDefault();
        }

        public void SaveChangesDb()
        {
            _context.SaveChanges();
        }
    }
}
