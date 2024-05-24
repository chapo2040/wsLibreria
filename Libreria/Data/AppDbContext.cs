using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext (options)
    {
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
