using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.POCO;
using AutoMapper;

namespace Api_Cadastro_Usuario.Mapper
{
    public class AutoMapperClass : Profile
    {
        public AutoMapperClass()
        {
            CreateMap<UsuarioViewModel, UsuarioModel>();
            CreateMap<UsuarioLogin, UsuarioModel>();

            CreateMap<TasksPostViewModel, TasksToDoModel>();
        }
    }
}
