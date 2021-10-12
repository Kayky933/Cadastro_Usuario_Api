using Api_Cadastro_Usuario.Data;
using Api_Cadastro_Usuario.Models.ViewModel;
using FizzWare.NBuilder;
using System;

namespace UnitTestsProject.Builder
{
    public class TasksBuilderModel : BuilderBase<TasksViewModel>
    {
        private readonly Api_Cadastro_UsuarioContext _usuarioRepository;
        protected override void LoadDefault()
        {
            _builderInstance = Builder<TasksViewModel>.CreateNew()
                  .With(x => x.Task = "Teste")
                  .With(x => x.Horario_Agendado = DateTime.Now.AddMinutes(10))
                  .With(x => x.Id_Usuario = _usuarioRepository.UsuarioModel.Find(x.Id_Usuario).Codigo);
        }
    }
}
