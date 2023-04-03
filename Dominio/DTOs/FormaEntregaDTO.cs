using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class FormaEntregaDTO
    {
        [Key]
        [Required]
        public int FormaEntregaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public List<ComandaDTO> LsComanda { get; set; }

    }
}
