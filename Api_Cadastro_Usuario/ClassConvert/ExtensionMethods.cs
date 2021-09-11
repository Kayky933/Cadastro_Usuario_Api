using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.ViewModel;

namespace Api_Cadastro_Usuario.ClassConvert
{
    public static class ExtensionMethods
    {
        public static UsuarioModel ViewModelToUsuario(this UsuarioViewModel viewModel)
        {
            UsuarioModel usuario = new();
            usuario.Nome = viewModel.Nome;
            usuario.Email = viewModel.Email;
            usuario.Data_Nascimento = viewModel.Data_Nascimento;
            usuario.Senha = viewModel.Senha;
            return usuario;
        }
    }
}
