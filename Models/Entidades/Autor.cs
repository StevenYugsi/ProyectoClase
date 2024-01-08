using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoClase.Models.Entidades
{
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        //public List<Usuario> Apellidos { get; internal set; }
        //public List<Usuario> Nombres { get; internal set; }

    }
}
