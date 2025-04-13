using GuateShop.Share.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuateShop.Backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Usuario> usuarios { get; set; } = null!;
        public DbSet<Pedido> pedidos { get; set; } = null!;
        public DbSet<DetallePedido> detallePedidos { get; set; } = null!;
        public DbSet<Country> countries { get; set; } = null!;
        public DbSet<State> states { get; set; } = null!;
        public DbSet<City> cities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Producto>().HasOne(p => p.categorias)
                .WithMany(c => c.productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Usuario)
                .WithMany(u => u.pedidos)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DetallePedido>().HasKey(dp => new { dp.PedidoId, dp.ProductoId });
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => new { x.StateId, x.Name }).IsUnique();        
        }
        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany
                (e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
