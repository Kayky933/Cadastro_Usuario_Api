using System;
using System.ComponentModel.DataAnnotations;

namespace Api_Cadastro_Usuario.Models
{
    public class UsuarioModel
    {
        [Key]
        public Guid Codigo { get; set; }       
        public string Nome { get; set; }       
        public DateTime Data_Nascimento { get; set; }       
        public string Email { get; set; }       
        public string Senha { get; set; }
    }
}
