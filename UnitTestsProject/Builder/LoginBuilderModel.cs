using Api_Cadastro_Usuario.POCO;
using FizzWare.NBuilder;

namespace UnitTestsProject.Builder
{
    public class LoginBuilderModel : BuilderBase<UsuarioLogin>
    {
        protected override void LoadDefault()
        {
            _builderInstance = Builder<UsuarioLogin>.CreateNew()
                 .With(x => x.Email = "teste@gmail.com")
                 .With(x => x.Senha = "12345678");
        }
    }
}
