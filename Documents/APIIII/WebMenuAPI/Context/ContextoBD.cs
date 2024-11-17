using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebMenuAPI.Models;

namespace WebMenuAPI.Context
{
    // ContextoBD class inherits from DbContext
    public class ContextoBD(IOptions<DbSettings> dbSettings) : DbContext
    {
        // DbSettings field to store the connection string
        private readonly DbSettings _dbSettings = dbSettings.Value;

        // DbSet properties to represent the tables in the database
        public required DbSet<Usuario> Usuarios { get; set; }
        public required DbSet<Orden> Ordenes { get; set; }
        public required DbSet<DetalleOrden> DetalleOrdenes { get; set; }
        public required DbSet<Producto> Productos { get; set; }
        public required DbSet<Categoria> Categorias { get; set; }
        public required DbSet<StatusOrden> StatusOrdenes { get; set; }
        public required DbSet<Comentario> Comentarios { get; set; }
        public required DbSet<Pago> Pagos { get; set; }
        public required DbSet<Locacion> Locaciones { get; set; }


        // Configuring the database provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        // Configuring the model for the entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orden>()
                .ToTable("Ordenes")
                .HasKey(o => o.OrdenId);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Usuario)
                .WithMany()
                .HasForeignKey(o => o.UsuarioId);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.StatusOrden)
                .WithMany()
                .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<Orden>()
                .HasOne(o => o.Locacion)
                .WithMany()
                .HasForeignKey(o => o.LocacionId);

            modelBuilder.Entity<DetalleOrden>()
                .ToTable("DetalleOrdenes")
                .HasKey(dt => dt.OrdenDtId);

            modelBuilder.Entity<DetalleOrden>()
                .HasOne(dt => dt.Orden)
                .WithMany()
                .HasForeignKey(dt => dt.OrdenId);

            modelBuilder.Entity<DetalleOrden>()
                .HasOne(dt => dt.Producto)
                .WithMany()
                .HasForeignKey(dt => dt.ProductoId);

            modelBuilder.Entity<Producto>()
                .ToTable("Productos")
                .HasKey(p => p.ProductoId);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Comentario>()
                .ToTable("Comentarios")
                .HasKey(c => c.ComentarioId);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Pago>()
                .ToTable("Pagos")
                .HasKey(p => p.PagoId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Orden)
                .WithMany()
                .HasForeignKey(p => p.OrdenId);

            modelBuilder.Entity<Locacion>()
                .ToTable("Locaciones")
                .HasKey(l => l.LocacionId);
        }
    }
}
