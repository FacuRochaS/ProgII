using Microsoft.EntityFrameworkCore;

namespace web_api24.Modelos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){ }
        // Constructor con parametro opciones
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        //1 properti por cada clase
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
