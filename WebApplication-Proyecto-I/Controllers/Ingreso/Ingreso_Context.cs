using Microsoft.EntityFrameworkCore;
using WebApplication_Proyecto_I.Controllers.Profesional;

namespace WebApplication_Proyecto_I.Controllers.Ingreso
{
    public partial class Ingreso_Context : DbContext
    {
        public Ingreso_Context() { }
        public Ingreso_Context(DbContextOptions<Ingreso_Context> options) : base(options) { }
        public virtual DbSet<WebApplication_Proyecto_I.Models.Ingreso.asociar_ingreso> Registros_ingreso { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=ProyectoI;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_Proyecto_I.Models.Ingreso.asociar_ingreso>(entity =>
            {
                entity.ToTable("credenciales");
                entity.Property(e => e.clinicaProfesional)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
