using Microsoft.EntityFrameworkCore;

namespace Api_Cadastro_Usuario.Data
{
    public class Api_Cadastro_UsuarioContext : DbContext
    {
        public Api_Cadastro_UsuarioContext(DbContextOptions<Api_Cadastro_UsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<Api_Cadastro_Usuario.Models.UsuarioModel> UsuarioModel { get; set; }
    }
}
