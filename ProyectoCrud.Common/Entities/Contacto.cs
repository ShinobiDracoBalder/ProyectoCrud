using System.ComponentModel.DataAnnotations;

namespace ProyectoCrud.Common.Entities
{
    public partial class Contacto
    {
        [Key]
        public int IdContacto { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
