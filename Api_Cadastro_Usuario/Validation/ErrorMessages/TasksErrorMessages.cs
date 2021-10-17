namespace Api_Cadastro_Usuario.Validation.ErrorMessages
{
    public class TasksErrorMessages
    {
        public static string TaskVazia = "A Task não pode ser vazia!";
        public static string TaskTamanhoMaximo = "O tamanho máximo de caracteres para uma task é de 500!";

        public static string TaskDataMinima = "Você não pode escolher uma data passada para o agendamento!";

        public static string TaskIdUsuarioInvalido = "Usuario não encontrado!";
        public static string TaskIdUsuarioVazio = "Id do Usuario vazio!";
    }
}
