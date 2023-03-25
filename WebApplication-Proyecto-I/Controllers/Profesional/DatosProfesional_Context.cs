using Microsoft.EntityFrameworkCore;

namespace WebApplication_Proyecto_I.Controllers.Profesional
{
    public partial class DatosProfesional_Context : DbContext
    {
        public DatosProfesional_Context() { }
        public DatosProfesional_Context(DbContextOptions<DatosProfesional_Context> options) : base(options) { }
        public virtual DbSet<WebApplication_Proyecto_I.Models.Profesional.asociar_profesional> Registros_Profesional{ get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=TareaII;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_Proyecto_I.Models.Profesional.asociar_profesional>(entity =>
            {
                entity.ToTable("");
                entity.Property(e => e.fechaRegistro)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
