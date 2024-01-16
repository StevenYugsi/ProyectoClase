using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoClase.Models.Entidades
{
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreEditorial { get; set; }

    }
}
