using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Cadastro_Usuario.ViewModel
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
