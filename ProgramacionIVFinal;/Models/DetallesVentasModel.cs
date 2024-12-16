using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.API.RESTful.Models
{
    [Table("DetalleVenta")]
    public class DetalleVentaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumeroVenta { get; set; }

        [Required]
        [MaxLength(255)]
        public string Articulo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioTotal { get; set; }

        // Calcula automáticamente el precio total basado en la cantidad y el precio unitario
        public void CalcularPrecioTotal()
        {
            PrecioTotal = Cantidad * PrecioUnitario;
        }
    }
}
