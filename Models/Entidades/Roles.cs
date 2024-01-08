using System.ComponentModel.DataAnnotations;

namespace ProyectoClase.Models.Entidades
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Rol { get; set; }
      
    }
}
