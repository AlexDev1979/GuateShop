using System.ComponentModel.DataAnnotations;

namespace GuateShop.Share.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int UsuarioId { get; set; }

        [Display(Name = "Fecha del pedido")]
        [Required]
        public DateTime FechaPedido { get; set; } = DateTime.Now;

        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que {1}.")]
        public decimal Total { get; set; }

        [Display(Name = "Estado del pedido")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(50)]
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Enviado, Entregado, Cancelado

        // Navegación
        public Usuario? Usuario { get; set; }

        public List<DetallePedido>? Detalles { get; set; }
    }
}