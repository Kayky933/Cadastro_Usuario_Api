using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.Validation.ErrorMessages;
using FluentValidation;

namespace Api_Cadastro_Usuario.Validation.BusinessValidation
{
    public class UsuarioBusinessValidation : AbstractValidator<UsuarioModel>
    {
        public UsuarioBusinessValidation(IUsuarioRepository usuario)
        {
            When(v => usuario.GetByEmail(v.Email)?.Codigo != v.Codigo, () =>
            {
                RuleFor(a => a.Email).Must(email => usuario.GetByEmail(email) == null).WithMessage(UsuarioErrorMessages.EmailJaCadastrado);
            });
        }
    }
}
