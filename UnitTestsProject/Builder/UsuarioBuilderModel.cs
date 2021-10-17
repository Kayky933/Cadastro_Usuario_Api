using Api_Cadastro_Usuario.Models.ViewModel;
using FizzWare.NBuilder;
using System;

namespace UnitTestsProject.Builder
{
    public class UsuarioBuilderModel : BuilderBase<UsuarioViewModel>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<UsuarioViewModel>.CreateNew()
                .With(x => x.Nome = "José")
                .With(x => x.Senha = "12345678")
                .With(x => x.Email = "teste@gmail.com")
                .With(x => x.Data_Nascimento = DateTime.Today.AddYears(-11));
        }
    }
}
