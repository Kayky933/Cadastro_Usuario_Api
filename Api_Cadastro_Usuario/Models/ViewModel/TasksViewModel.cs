using System;

namespace Api_Cadastro_Usuario.Models.ViewModel
{
    public class TasksViewModel
    {
        public string Task { get; set; }
        public DateTime Horario_Agendado { get; set; }
        public Guid Id_Usuario { get; set; }
    }
}
