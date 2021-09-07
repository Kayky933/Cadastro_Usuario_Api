using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Api_Cadastro_UsuarioContext _context;
        public UsuarioRepository(Api_Cadastro_UsuarioContext context)
        {
            _context = context;
        }
        public void Create(UsuarioModel model)
        {
            throw new NotImplementedException();
        }

        public void Delet(UsuarioModel model)
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
