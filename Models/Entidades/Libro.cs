using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoClase.Models.Entidades
{

    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Titulo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }

        public DateTime FechaRegitro { get; set; }
        public string URLLibro { get; set; }
        public bool Estado { get; set; }
        public int idCategoria { get; set; }
        public int idAutor { get; set; }
        public int idEditorial { get; set; }
        public Autor autor { get; set; }
        public Editorial editorial { get; set; }
        public Categoria categoria { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Categorias { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Autores { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Editoriales { get; set; }
    }
}
