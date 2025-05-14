using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tiendaRopa_Api.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
