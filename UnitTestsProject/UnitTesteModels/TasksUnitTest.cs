using Api_Cadastro_Usuario.Validation.ErrorMessages;
using Api_Cadastro_Usuario.Validation.ModelsValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UnitTestsProject.Builder;
using Xunit;

namespace UnitTestsProject.UnitTesteModels
{
    public class TasksUnitTest
    {
        private readonly TasksBuilderModel _task;
        private readonly TaskValidationModel _validation;
        public TasksUnitTest()
        {
            var provider = new ServiceCollection().AddScoped<TaskValidationModel>().BuildServiceProvider();
            _task = new TasksBuilderModel();
            _validation = provider.GetService<TaskValidationModel>();

        }
        [Fact(DisplayName = "A clesse deve ser válida!")]
        public async Task ClasseValida()
        {
            var instance = _task.Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }

        #region Teste de Tasks
        [Theory(DisplayName = "Teste de Tasks válidas")]
        [InlineData("a")]
        [InlineData("abc")]
        [InlineData("teste de tasks")]
        [InlineData("hhhhhhh")]
        [InlineData("nnkdnkcnkjs")]
        [InlineData("kkkkkkkkk")]
        public async Task TasksValidas(string task)
        {
            var instance = _task.With(x => x.Task = task).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Fact(DisplayName = "Teste de tamanho máximo do nome")]
        public async Task TamanhoMaximoTask()
        {
            var instance = _task.With(x => x.Task = "A".PadLeft(499, 'a')).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.True(validation.IsValid);
        }
        [Theory(DisplayName = "Teste de Tasks inválidas")]
        [InlineData("")]
        [InlineData(" ")]
        public async Task TasksInvalidas(string task)
        {
            var instance = _task.With(x => x.Task = task).Build();
            var validation = await _validation.ValidateAsync(instance);


            Assert.False(validation.IsValid);

            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(TasksErrorMessages.TaskVazia));
        }
        [Fact(DisplayName = "Teste tamanho máximo da task")]
        public async Task TaskTamanhoMaximo()
        {
            var instance = _task.With(x => x.Task = "A".PadLeft(501, 'a')).Build();
            var validation = await _validation.ValidateAsync(instance);
            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(TasksErrorMessages.TaskTamanhoMaximo));
        }
        #endregion

        #region Teste de Datas válidas
        [Theory(DisplayName = "Teste de datas válidas")]
        [InlineData("10/01/2022")]
        [InlineData("01/02/2023")]
        [InlineData("10/11/2021")]
        [InlineData("10/10/2025")]
        [InlineData("10/01/2025")]
        public async Task DatasValidas(string dataStr)
        {
            var instance = _task.With(x => x.Horario_Agendado = DateTime.Parse(dataStr)).Build();
            var validation = await _validation.ValidateAsync(instance);

            Assert.True(validation.IsValid);
        }

        [Theory(DisplayName = "Teste de datas Inválidas")]
        [InlineData("01/01/2021")]
        [InlineData("01/02/2019")]
        [InlineData("03/01/2018")]
        public async Task DatasInvalidas(string dataStr)
        {
            var instance = _task.With(x => x.Horario_Agendado = DateTime.Parse(dataStr)).Build();
            var validation = await _validation.ValidateAsync(instance);

            Assert.False(validation.IsValid);
            Assert.Contains(validation.Errors, x => x.ErrorMessage.Contains(TasksErrorMessages.TaskDataMinima));
        }
        #endregion
    }
}
