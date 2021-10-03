namespace Api_Cadastro_Usuario.Validation.ErrorMessages
{
    public class UsuarioErrorMessages
    {
        public static string NomeVazio = "O Campo Nome não pode ser vazio!";
        public static string NomeTamanhoMaximo = "O Campo Nome não pode ter mais que 100 caracteres!";
        public static string NomeTamanhoMinimo = "O Campo Nome tem que ter no mínimo 3 caracteres!";

        public static string EmailVazio = "O Campo Email  não pode ser vazio!";
        public static string EmailtamanhoMaximo = "O Campo E-mail não pode ter mais que 150 caracteres!";
        public static string EmailtamanhoMinimo = "O Campo E-mail tem que ter no mínimo 7 caracteres!";
        public static string EmailFormato = "O Campo E-mail precisa ser do tipo e-mail(ex:exemplo@exemplo;com)";

        public static string DataVazia = "O Campo EData de Nascimento não pode ser vazio!";
        public static string DataMinima = "Para se cadastrar você tem que ter no mínimo 11 anos!";

        public static string SenhaVazia = "O Campo Senha não pode ser vazio!";
        public static string SenhaTamanhoMaximo = "O Campo Senha não pode ter mais que 100 caracteres!";
        public static string SenhaTamanhoMinimo = "O campo Senha tem que ter no mínimo 8 caracteres!";

    }
}
