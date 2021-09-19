using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Cadastro_Usuario.Models
{
    [Table("Tasks")]
    public class TasksToDoModel
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(400)]
        [MinLength(10)]
        public string Task { get; set; }
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime Horario_Post { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime Horario_Agendado { get; set; }
        [ForeignKey("Usuario")]
        public Guid Id_Usuario { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
