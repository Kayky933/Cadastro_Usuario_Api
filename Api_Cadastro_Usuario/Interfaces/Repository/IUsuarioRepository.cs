using Api_Cadastro_Usuario.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        public IEnumerable<object> GetAllTasks(Guid id);
        public void Create(UsuarioModel usuario);
        public UsuarioModel Login(UsuarioModel usuario);
        public DbSet<UsuarioModel> GetContext();
        public void Put(UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByPassword(string senha);

    }
}
