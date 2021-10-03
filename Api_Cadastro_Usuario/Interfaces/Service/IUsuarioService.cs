using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id);
        public ValidationResult Create(UsuarioViewModel usuario);
        public ValidationResult Login(UsuarioLogin loginUsuario);
        public DbSet<UsuarioModel> GetContext();
        public ValidationResult Put(Guid id, UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByPassword(string senha);
    }
}
