using System.ComponentModel.DataAnnotations;

namespace WebApplication_Proyecto_I.Models.Ingreso
{
    public partial class asociar_ingreso
    {
        [Key]
        public int idProfesional { get; set; }
        public int codigo_profesional { get; set; }
        public string? clinicaProfesional { get; set; }
    }
}
