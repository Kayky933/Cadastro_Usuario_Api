using Api_Cadastro_Usuario.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        public void Create(UsuarioModel usuario);
        public UsuarioModel Login(UsuarioModel usuario);
        public DbSet<UsuarioModel> GetContext();
        public UsuarioModel Put(Guid id, UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByPassword(string senha);
    }
}
