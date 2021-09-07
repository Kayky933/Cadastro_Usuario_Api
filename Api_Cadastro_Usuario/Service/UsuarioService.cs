using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioModel Create(UsuarioModel model)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Delet(UsuarioModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public UsuarioLogin Login(UsuarioLogin loginUsuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel Post(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
