using Microsoft.EntityFrameworkCore;
using WebApplication_Proyecto_I.Controllers.Ingreso;

namespace WebApplication_Proyecto_I.Controllers.Inyecciones
{
    public partial class Inyecciones_Context : DbContext
    {
        public Inyecciones_Context() { }
        public Inyecciones_Context(DbContextOptions<Inyecciones_Context> options) : base(options) { }
        public virtual DbSet<WebApplication_Proyecto_I.Models.Inyecciones.asociar_inyecciones> Registros_inyecciones { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=ProyectoI;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_Proyecto_I.Models.Inyecciones.asociar_inyecciones>(entity =>
            {
                entity.ToTable("datosInyecciones");
                entity.Property(e => e.Sarampión_Rubeola_Parotiditis)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
