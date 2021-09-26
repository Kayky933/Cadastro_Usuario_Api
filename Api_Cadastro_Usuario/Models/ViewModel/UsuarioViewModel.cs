using System;

namespace Api_Cadastro_Usuario.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
