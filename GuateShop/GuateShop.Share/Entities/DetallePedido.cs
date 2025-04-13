using System.ComponentModel.DataAnnotations;

namespace GuateShop.Share.Entities
{
    public class DetallePedido
    {
        public int Id { get; set; }

        [Display(Name = "Pedido")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int PedidoId { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int ProductoId { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} debe ser al menos {1}.")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio unitario")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Subtotal")]
        public decimal Subtotal => Cantidad * PrecioUnitario;

        // Navegación
        public Pedido? Pedido { get; set; }

        public Producto? Producto { get; set; }
    }
}