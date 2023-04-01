using Microsoft.EntityFrameworkCore;
using WebApplication_Proyecto_I.Controllers.Profesional;

namespace WebApplication_Proyecto_I.Controllers.Sintoma
{
    public partial class Sintomas_Context : DbContext
    {
        public Sintomas_Context() { }
        public Sintomas_Context(DbContextOptions<Sintomas_Context> options) : base(options) { }
        public virtual DbSet<WebApplication_Proyecto_I.Models.Sintomas.asociar_sintomas> Registros_Sintomas { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=ProyectoI;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_Proyecto_I.Models.Sintomas.asociar_sintomas>(entity =>
            {
                entity.ToTable("datosSintomas");

                entity.Property(e => e.T0)
                    .HasMaxLength(300)
                    .IsUnicode(false);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
