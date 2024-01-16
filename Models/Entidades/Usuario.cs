using System.ComponentModel.DataAnnotations;
        
namespace ProyectoClase.Models.Entidades
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreUsuario { get; set; } = null;
        public string? URLFotoPerfil { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        //public int idRol { get; set; } = 0;
        //public Roles roles { get; set; } 


    }
}
