using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Validation.BusinessValidation;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ValidationResult Create(UsuarioViewModel usuario)
        {
            var validation = ValidateModelViewsusuario(usuario);
            if (validation.IsValid)
            {
                var response = _mapper.Map<UsuarioModel>(usuario);
                response.Role = "User";
                response.Nome.ToUpper().Trim();
                response.Senha.Trim();
                _repository.Create(response);
            }
            return validation;
        }
        private ValidationResult ValidateModelViewsusuario(UsuarioViewModel usuario)
        {
            var business = _mapper.Map<UsuarioModel>(usuario);
            var validation = new PostUsuarioValidation().Validate(usuario);
            var validationBusiness = new UsuarioBusinessValidation(_repository).Validate(business);

            if (!validation.IsValid)
                return validation;

            if (!validationBusiness.IsValid)
                return validationBusiness;

            return validation;

        }
        public IEnumerable<object> GetAllTasks(Guid id)
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
            var usuario = _mapper.Map<UsuarioModel>(loginUsuario);
            var validation = new LoginUsuarioValidation(_repository).Validate(loginUsuario);
            if (!validation.IsValid)
                return validation;

            var response = _repository.Login(usuario);
            if (response == null)
                return validation;

            return validation;
        }

        public ValidationResult Put(Guid id, UsuarioViewModel usuario)
        {
            var validation = new PostUsuarioValidation().Validate(usuario);

            if (validation.IsValid)
            {
                var usuarioValidado = _mapper.Map<UsuarioModel>(usuario);
                usuarioValidado.Role = "User";
                _repository.Put(id, usuarioValidado);
            }

            return validation;
        }
    }
}
