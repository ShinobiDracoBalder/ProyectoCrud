using System.ComponentModel.DataAnnotations;

namespace ProyectoCrud.Common.Entities
{
    public class Detalle_Venta
    {
        [Key]
        public int IdDetalleVenta { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
