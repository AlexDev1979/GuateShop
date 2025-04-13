using System.ComponentModel.DataAnnotations;

namespace GuateShop.Share.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Display(Name = "Producto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string? Descripcion { get; set; }

        [Display(Name = "Precio")]
        [Range(0.01, 99999.99, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Precio { get; set; }

        [Display(Name = "Stock disponible")]
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Display(Name = "URL de la imagen")]
        public string? ImagenUrl { get; set; }
        public Categoria categorias { get; set; } = null!; // Assuming a one-to-many relationship
        public int CategoriaId { get; set; } // Foreign key property
    }
}