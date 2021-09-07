using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.Models
{
    public class UsuarioModel
    {
        [Key]
        public Guid Codigo { get; set; }
        [MaxLength(100, ErrorMessage = "O Nome excedeu o número de caracteres permitidos")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }
        [DataType(DataType.Time)]
        public DateTime Data_Nascimento { get; set; }
        [MaxLength(200, ErrorMessage = "O Email excedeu o número de caracteres permitidos")]
        [MinLength(7, ErrorMessage = "O Email deve ter no mínimo 7 caracteres")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        public string Email { get; set; }
        [MaxLength(200, ErrorMessage = "A Senha excedeu o número de caracteres permitidos")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        public string Senha { get; set; }
    }
}
