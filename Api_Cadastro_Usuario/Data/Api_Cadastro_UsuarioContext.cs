using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Cadastro_Usuario.Models;

namespace Api_Cadastro_Usuario.Data
{
    public class Api_Cadastro_UsuarioContext : DbContext
    {
        public Api_Cadastro_UsuarioContext (DbContextOptions<Api_Cadastro_UsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<Api_Cadastro_Usuario.Models.UsuarioModel> UsuarioModel { get; set; }
    }
}
