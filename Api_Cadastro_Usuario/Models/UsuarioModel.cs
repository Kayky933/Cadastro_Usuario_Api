using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Cadastro_Usuario.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        public Guid Codigo { get; set; }
        [MaxLength(100)]
        [MinLength(3)]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_Nascimento { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(100)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
