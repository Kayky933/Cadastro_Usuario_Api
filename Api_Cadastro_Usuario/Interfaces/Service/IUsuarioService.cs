using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public UsuarioViewModel Create(UsuarioViewModel usuario);
        public UsuarioLogin Login(UsuarioLogin loginUsuario);
        public DbSet<UsuarioModel> GetContext();
        public UsuarioModel Put(Guid id, UsuarioModel usuario);
        public UsuarioModel GetByEmail(string email);
        public UsuarioModel GetByPassword(string senha);
    }
}
