using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoClase.Models.Entidades
{
    public class Ventas
    {
        [Key]
        public int IdVentas { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal IVA { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal Total { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [NotMapped]
        public string FechaVenta { get; set; }
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }

    }
}
