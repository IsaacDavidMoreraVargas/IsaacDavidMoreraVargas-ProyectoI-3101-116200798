using System.ComponentModel.DataAnnotations;

namespace WebApplication_Proyecto_I.Models.Inyecciones
{
    public class asociar_inyecciones
    {
        [Key]
        public int Identificacion_Paciente { get; set; }
        public string Sarampión_Rubeola_Parotiditis { get; set; }

        public string Tetano_Hepatitis_A_B_Influenza { get; set; }

        public string Vacuna_Covid { get; set; }

        public int? Cuantas_Dosis { get; set; }

        public string? Razon_Covid { get; set; }
    }
}
