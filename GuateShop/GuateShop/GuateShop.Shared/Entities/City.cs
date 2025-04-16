using System.ComponentModel.DataAnnotations;

namespace GuateShop.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Municipio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas  de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }
        public State? State { get; set; }
        public ICollection<User> Useres { get; set; } = new List<User>();
    }
}