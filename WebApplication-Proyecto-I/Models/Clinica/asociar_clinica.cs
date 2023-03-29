using System.ComponentModel.DataAnnotations;

namespace WebApplication_Proyecto_I.Models.Clinica
{
    public partial class asociar_clinica
    {
        [Key]
        public int Cedula_Juridica_Clinica { get; set; }
 
        public string? Nombre_Clinica{ get; set; }

        public int? Telefono_Administracion_Clinica { get; set; }

        public string? Correo_Electronico_Administracion { get; set; }

        public string? Pais_Clinica { get; set; }

        public string? Estado_Provincia_Clinica { get; set; }

        public string? Distrito_Clinica { get; set; }
    }
}
