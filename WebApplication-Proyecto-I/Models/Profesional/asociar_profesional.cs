using System.ComponentModel.DataAnnotations;

namespace WebApplication_Proyecto_I.Models.Profesional
{
    public partial class asociar_profesional
    {
        [Key]
        public int Identificacion_Profesional { get; set; }

        public int Codigo_Profesional { get; set; }

        public string Nombre_Completo_Profesional { get; set; }

        public string Correo_Electronico_Profesional { get; set; }

        public string Pais_Residencia_Profesional { get; set; }

        public string Estado_Provincia_Residencia_Profesional { get; set; }

    }
        
}
