using Api_Cadastro_Usuario.Validation.ErrorMessages;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UnitTestsProject.Builder;
using Xunit;

namespace UnitTestsProject.UnitTesteModels
{
    public class UsuarioUnitTest
    {
        private readonly UsuarioBuilderModel _usuario;
        private readonly PostUsuarioValidation _validation;
        public UsuarioUnitTest()
        {
            var provider = new ServiceCollection().AddScoped<PostUsuarioValidation>().BuildServiceProvider();
            _usuario = new UsuarioBuilderModel();
            _validation = provider.GetService<PostUsuarioValidation>();
        }

        [Fact(DisplayName = "A classe deve ser válida")]
        public async Task ClasseValida()
        {
            var instance = _usuario.Build();

            var validation = await _validation.ValidateAsync(instance);

            Assert.True(validation.IsValid);
        }

        #region Teste de Nomes
        [Theory(DisplayName = "Teste de Nomes válidos")]
        [InlineData("José")]
        [InlineData("joão")]
        [InlineData("Eva")]
        [InlineData("Adão")]
        public async Task NomesValidos(string nome)
        {
            var instance = _usuario.With(x => x.Nome = nome).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Teste de Nomes invalidos")]
        [InlineData("Je")]
        [InlineData("Ma")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Jo")]
        public async Task NomesInvalidos(string nome)
        {
            var instance2 = _usuario.With(x => x.Nome = "A".PadLeft(101, 'A')).Build();

            var instance1 = _usuario.With(x => x.Nome = nome).Build();
            var validation1 = await _validation.ValidateAsync(instance1);
            var validation2 = await _validation.ValidateAsync(instance2);
            Assert.False(validation1.IsValid);
            Assert.False(validation2.IsValid);
            Assert.Contains(validation1.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeTamanhoMinimo));
            Assert.Contains(validation2.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.NomeTamanhoMaximo));
        }

        #endregion

        #region Testes de Email
        [Theory(DisplayName = "Emails devem ser Válidos")]
        [InlineData("teste@gmail.com")]
        [InlineData("teste@hotmail.com")]
        [InlineData("teste@yahool.com")]
        [InlineData("teste@teste.com")]
        [InlineData("a@gmail.com")]
        public async Task EmailsValidos(string email)
        {
            var instance = _usuario.With(x => x.Email = email).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Teste de emails formato inválidos")]
        [InlineData("aaaaa")]
        [InlineData("aaaaa@")]
        [InlineData("@aaaaa")]
        [InlineData("aaaaa.com")]
        public async Task EmailFormatoInvalido(string email)
        {
            var instance = _usuario.With(x => x.Email = email).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailFormato));
        }
        [Fact(DisplayName = "Email nulo!")]
        public async Task EmailsNulo()
        {
            var instance = _usuario.With(x => x.Email = "").Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.EmailVazio));
        }
        #endregion

        #region Teste de Senhas
        [Theory(DisplayName = "Teste de senhas Válidas")]
        [InlineData("12345678")]
        [InlineData("uudbyfyybduybwbYubub")]
        [InlineData("liajajniinUN_jj")]
        [InlineData("JJJJhhGhgyhnHbguh")]
        [InlineData("111111111111111111")]
        public async Task SenhasValidas(string senha)
        {
            var instance = _usuario.With(x => x.Senha = senha).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Teste de senhas Inválidas")]
        [InlineData("")]
        [InlineData("1234567")]
        [InlineData("1")]
        [InlineData("1234")]
        [InlineData(" ")]
        [InlineData("44")]
        public async Task SenhasInvalidas(string senha)
        {
            var instance1 = _usuario.With(x => x.Senha = senha).Build();
            var instance2 = _usuario.With(x => x.Senha = "1".PadLeft(101, '1')).Build();

            var validation1 = await _validation.ValidateAsync(instance1);
            var validation2 = await _validation.ValidateAsync(instance2);
            Assert.False(validation1.IsValid);
            Assert.False(validation2.IsValid);
            Assert.Contains(validation1.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaTamanhoMinimo));
            Assert.Contains(validation2.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaTamanhoMaximo));
        }
        [Fact(DisplayName = "Senha nulo!")]
        public async Task SenhaVazia()
        {
            var instance = _usuario.With(x => x.Senha = "").Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.SenhaVazia));
        }
        #endregion

        #region Teste de Datas Válidas
        [Theory(DisplayName = "Teste de datas válidas")]
        [InlineData("10/01/2004")]
        [InlineData("01/02/2000")]
        [InlineData("10/01/2005")]
        [InlineData("10/10/2003")]
        [InlineData("10/01/1999")]
        public async Task DatasValidas(string dataStr)
        {
            var instance = _usuario.With(x => x.Data_Nascimento = DateTime.Parse(dataStr)).Build();
            var validation = await _validation.ValidateAsync(instance);

            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Teste de datas Inválidas")]
        [InlineData("01/01/2021")]
        [InlineData("01/02/2019")]
        [InlineData("03/01/2018")]
        public async Task DatasInvalidas(string dataStr)
        {
            var instance = _usuario.With(x => x.Data_Nascimento = DateTime.Parse(dataStr)).Build();
            var validation = await _validation.ValidateAsync(instance);

            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(UsuarioErrorMessages.DataMinima));
        }
        #endregion


    }
}
