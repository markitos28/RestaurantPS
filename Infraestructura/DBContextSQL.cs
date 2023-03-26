using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Infraestructura
{
    public class DBContextSQL: DbContext
    {
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderia { get; set; }
        public DbSet<FormaEntrega> FormaEntrega { get; set; }
        public DbSet<Mercaderia> Mercaderia { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderia { get; set; }
        public DBContextSQL(DbContextOptions<DBContextSQL> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = staging; User Id = default; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.HasKey(s => s.ComandaId);
                entity.HasOne<FormaEntrega>(o => o.FKFormaEntrega).WithMany(m => m.LsComanda);

            });
        }
    }
}
