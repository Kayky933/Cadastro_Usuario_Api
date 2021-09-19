using System;

namespace Api_Cadastro_Usuario.POCO
{
    public class UsuarioLogin
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid Id { get; set; }
    }
}
