using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.Validation.ErrorMessages;
using FluentValidation;
using System;

namespace Api_Cadastro_Usuario.Validation.ModelsValidation
{
    public class TaskValidationModel : AbstractValidator<TasksPostViewModel>
    {
        public TaskValidationModel()
        {
            RuleFor(a => a.Task).NotEmpty().WithMessage(TasksErrorMessages.TaskVazia)
                .MaximumLength(500).WithMessage(TasksErrorMessages.TaskTamanhoMaximo);

            RuleFor(a => a.Horario_Agendado).Must(DataMinimaAgendamento).WithMessage(TasksErrorMessages.TaskDataMinima);
        }
        private bool DataMinimaAgendamento(DateTime data)
        {
            return data >= DateTime.Now;
        }
    }
}
