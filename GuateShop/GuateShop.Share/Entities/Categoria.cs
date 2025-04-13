using System.ComponentModel.DataAnnotations;

namespace GuateShop.Share.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; } = null!;
        public ICollection<Producto> productos { get; set; } = new List<Producto>();
    }
}