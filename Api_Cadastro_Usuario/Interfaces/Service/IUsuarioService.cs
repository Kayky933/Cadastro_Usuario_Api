using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public UsuarioViewModel Create(UsuarioViewModel usuario);
        public UsuarioViewModel Login(UsuarioViewModel loginUsuario);
        public DbSet<UsuarioModel> GetContext();
        public UsuarioModel Put(Guid id, UsuarioModel usuario);
    }
}
