using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoClase.Models.Entidades
{

    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string categoria { get; set; }
        public string Descripcion { get; set; }


    }

}
