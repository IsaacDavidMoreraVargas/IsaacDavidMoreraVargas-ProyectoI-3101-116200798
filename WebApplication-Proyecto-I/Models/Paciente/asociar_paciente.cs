using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace WebApplication_Proyecto_I.Models.Paciente
{
    public partial class asociar_paciente
    {
        [Key]
        public int Identificacion_Paciente { get; set; }
        
        public string? Nombre_Paciente { get; set; }

        public string? Primer_Apellido_Paciente { get; set; }

        public string? Segundo_Apellido_Paciente { get; set; }

        public string? Fecha_Nacimiento_Paciente { get; set; }

        public int Telefono_Contacto_Paciente { get; set; }

        public string Correo_Electronico_Paciente { get; set; }

        public string? Fecha_Registro { get; set; }

        public string? Ocupacion_Paciente { get; set; }

        public string? Pais_Paciente { get; set; }

        public string? Estado_Provincia_Paciente { get; set; }

        public string? Distrito_Paciente { get; set; }

        public string? Genero_Paciente { get; set; }

        public string? Estado_Civil_Paciente { get; set; }

    }
}
