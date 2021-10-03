using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.Validation.ErrorMessages;
using FluentValidation;

namespace Api_Cadastro_Usuario.Validation.ModelsValidation
{
    public class LoginUsuarioValidation : AbstractValidator<UsuarioLogin>
    {
        public LoginUsuarioValidation(IUsuarioRepository user)
        {
            RuleFor(a => a.Email).NotEmpty().WithMessage(UsuarioErrorMessages.EmailVazio)
                .Must(email => user.GetByEmail(email) != null).WithMessage(UsuarioErrorMessages.EmailIncorreto);

            RuleFor(a => a.Senha).NotEmpty().WithMessage(UsuarioErrorMessages.SenhaVazia)
                .Must(senha => user.GetByPassword(senha) != null).WithMessage(UsuarioErrorMessages.SenhaIncorreta);

        }
    }
}
