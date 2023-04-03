using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class ComandaMercaderiaDTO
    {
        [Key]
        [Required]
        public int ComandaMercaderiaId { get; set; }
        [Required]
        public int MercaderiaId { get; set; }
        [Required]
        public Guid ComandaId { get; set; }

    }
}
