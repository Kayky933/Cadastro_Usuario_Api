using Api_Cadastro_Usuario.Models.ViewModel;
using FizzWare.NBuilder;
using System;

namespace UnitTestsProject.Builder
{
    public class TasksBuilderModel : BuilderBase<TasksPostViewModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<TasksPostViewModel>.CreateNew()
                  .With(x => x.Task = "Teste")
                  .With(x => x.Horario_Agendado = DateTime.Now.AddMinutes(10));
        }
    }
}
