using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.Validation.ErrorMessages;
using FluentValidation;
using System;

namespace Api_Cadastro_Usuario.Validation.ModelsValidation
{
    public class TaskValidationModel : AbstractValidator<TasksViewModel>
    {
        public TaskValidationModel(ITasksToDoRepository repository)
        {
            RuleFor(a => a.Task).NotEmpty().WithMessage(TasksErrorMessages.TaskVazia)
                .MaximumLength(500).WithMessage(TasksErrorMessages.TaskTamanhoMaximo);

            RuleFor(a => a.Horario_Agendado).Must(DataMinimaAgendamento).WithMessage(TasksErrorMessages.TaskDataMinima);

            RuleFor(a => a.Id_Usuario).NotEmpty().WithMessage(TasksErrorMessages.TaskIdUsuarioVazio)
                .Must(usuarioId => repository.GetOneUsuario(usuarioId) != null).WithMessage(TasksErrorMessages.TaskIdUsuarioInvalido);

        }
        private bool DataMinimaAgendamento(DateTime data)
        {
            return data >= DateTime.Now;
        }
    }
}
