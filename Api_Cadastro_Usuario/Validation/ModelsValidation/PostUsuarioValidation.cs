using Api_Cadastro_Usuario.Models.ViewModel;
using Api_Cadastro_Usuario.Validation.ErrorMessages;
using FluentValidation;
using System;

namespace Api_Cadastro_Usuario.Validation.ModelsValidation
{
    public class PostUsuarioValidation : AbstractValidator<UsuarioViewModel>
    {
        public PostUsuarioValidation()
        {
            RuleFor(a => a.Nome).NotEmpty().WithMessage(UsuarioErrorMessages.NomeVazio)
                .MaximumLength(100).WithMessage(UsuarioErrorMessages.NomeTamanhoMaximo)
                .MinimumLength(3).WithMessage(UsuarioErrorMessages.NomeTamanhoMinimo);

            RuleFor(a => a.Email).NotEmpty().WithMessage(UsuarioErrorMessages.EmailVazio)
                .EmailAddress().WithMessage(UsuarioErrorMessages.EmailFormato)
                 .MaximumLength(100).WithMessage(UsuarioErrorMessages.EmailtamanhoMaximo)
                .MinimumLength(7).WithMessage(UsuarioErrorMessages.EmailtamanhoMinimo);

            RuleFor(a => a.Senha).NotEmpty().WithMessage(UsuarioErrorMessages.SenhaVazia)
               .MaximumLength(100).WithMessage(UsuarioErrorMessages.SenhaTamanhoMaximo)
               .MinimumLength(8).WithMessage(UsuarioErrorMessages.SenhaTamanhoMinimo);

                RuleFor(a => a.Data_Nascimento).NotEmpty().WithMessage(UsuarioErrorMessages.DataVazia)
                    .Must(IdadeMinima).WithMessage(UsuarioErrorMessages.DataMinima);
        }
        private bool IdadeMinima(DateTime data)
        {
            return data <= DateTime.Today.AddYears(-11);
        }
    }
}
