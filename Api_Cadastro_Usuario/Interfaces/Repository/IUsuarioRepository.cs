using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Interfaces.Repository
{
   public  interface IUsuarioRepository:IBaseRepository<UsuarioModel>
    {
        public UsuarioViewModel Post(UsuarioViewModel usuario);
        public UsuarioLogin Login(UsuarioLogin loginUsuario);
    }
}
