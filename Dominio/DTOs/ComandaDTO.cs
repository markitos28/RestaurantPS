using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class ComandaDTO
    {
        [Key]
        [Required]
        public Guid ComandaId { get; set; }
        [Required]
        public int FormaEntregaId { get; set; }
        [Required]
        public int PrecioTotal { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
