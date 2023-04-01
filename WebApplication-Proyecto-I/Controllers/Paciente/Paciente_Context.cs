using Microsoft.EntityFrameworkCore;
using WebApplication_Proyecto_I.Controllers.Profesional;

namespace WebApplication_Proyecto_I.Controllers.Paciente
{
    public partial class Paciente_Context : DbContext
    {

        public Paciente_Context() { }
        public Paciente_Context(DbContextOptions<Paciente_Context> options) : base(options) { }
        public virtual DbSet<WebApplication_Proyecto_I.Models.Paciente.asociar_paciente> Registros_Paciente { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVLLMUB;Database=ProyectoI;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebApplication_Proyecto_I.Models.Paciente.asociar_paciente>(entity =>
            {
                entity.ToTable("datosPaciente");

                entity.Property(e => e.Nombre_Paciente)
                    .HasMaxLength(300)
                    .IsUnicode(false);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
