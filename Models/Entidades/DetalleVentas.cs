using System.ComponentModel.DataAnnotations;

namespace ProyectoClase.Models.Entidades
{
    public class DetalleVentas
    {
        [Key]
        public int IdDetalleVetan { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Cantidad { get; set; }
        public int idVenta { get; set; }
        public int idLibro { get; set; }
        public Ventas ventas { get; set; }
        public Libro libro { get; set; }

    }
}
