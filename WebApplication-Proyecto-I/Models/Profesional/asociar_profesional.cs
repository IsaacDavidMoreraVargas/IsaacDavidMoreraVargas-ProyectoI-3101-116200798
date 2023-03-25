using System.ComponentModel.DataAnnotations;

namespace WebApplication_Proyecto_I.Models.Profesional
{
    public partial class asociar_profesional
    {
        [Key]
        public int idRegistro { get; set; }

        public int idEmpleadoAsociado { get; set; }

        public int idPuestoAsociado { get; set; }

        public string? fechaRegistro { get; set; }
    }
}
