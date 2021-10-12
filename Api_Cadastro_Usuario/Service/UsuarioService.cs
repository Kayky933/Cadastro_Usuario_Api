using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Validation.BusinessValidation;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ValidationResult Create(UsuarioViewModel usuario)
        {
            var validation = ValidateModelViewsusuario(usuario);
            if (validation.IsValid)
            {
                var response = usuario.ViewModelToUsuario();
                response.Role = "User";
                response.Nome.ToUpper().Trim();
                response.Senha.Trim();
                _repository.Create(response);
            }
            return validation;
        }
        private ValidationResult ValidateModelViewsusuario(UsuarioViewModel usuario)
        {
            var business = usuario.ViewModelToUsuario();
            var validation = new PostUsuarioValidation().Validate(usuario);
            var validationBusiness = new UsuarioBusinessValidation(_repository).Validate(business);

            if (!validation.IsValid)
                return validation;

            if (!validationBusiness.IsValid)
                return validationBusiness;

            return validation;

        }
        public IEnumerable<TasksToDoModel> GetAllTasks(Guid id)
        {
            return _repository.GetAllTasks(id);

        }
        public UsuarioModel Delet(Guid model)
        {
            var usuario = _repository.GetOne(model);
            if (usuario == null)
                return null;
            _repository.Delet(usuario);
            return usuario;
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return _repository.GetAll();
        }

        public UsuarioModel GetByEmail(string email)
        {
            var response = _repository.GetByEmail(email);
            if (response == null)
                return null;
            return response;
        }
        public UsuarioModel GetByPassword(string senha)
        {
            var response = _repository.GetByPassword(senha);
            if (response == null)
                return null;
            return response;
        }
        public DbSet<UsuarioModel> GetContext()
        {
            return _repository.GetContext();
        }

        public UsuarioModel GetOne(Guid codigo)
        {
            var response = _repository.GetOne(codigo);
            if (response == null)
                return null;
            return response;
        }

        public ValidationResult Login(UsuarioLogin loginUsuario)
        {
            var usuario = loginUsuario.LoginModelToUsuario();
            var validation = new LoginUsuarioValidation(_repository).Validate(loginUsuario);
            if (!validation.IsValid)
                return validation;

            var response = _repository.Login(usuario);
            if (response == null)
                return validation;

            return validation;
        }

        public ValidationResult Put(Guid id, UsuarioModel usuario)
        {

            var usuarioValidate = usuario.UsuarioModelToView();
            var validation = new PostUsuarioValidation().Validate(usuarioValidate);

            if (validation.IsValid)
            {
                _repository.Put(id, usuario);
            }

            return validation;
        }
    }
}
