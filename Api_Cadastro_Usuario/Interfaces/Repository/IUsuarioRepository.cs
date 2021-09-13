using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using System;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        public void Create(UsuarioModel usuario);
        public UsuarioLogin Login(UsuarioLogin loginUsuario);
        public UsuarioModel Put(Guid id, UsuarioModel usuario);
    }
}
