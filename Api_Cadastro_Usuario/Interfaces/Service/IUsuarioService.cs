using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Service
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        public UsuarioViewModel Create(UsuarioViewModel usuario);
        public UsuarioViewModel Login(UsuarioViewModel loginUsuario);
        public UsuarioModel Put(Guid id, UsuarioModel usuario);
    }
}
