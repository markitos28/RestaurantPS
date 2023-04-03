using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class TipoMercaderiaDTO
    {
        [Required]
        [Key]
        public int TipoMercaderiaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        public List<MercaderiaDTO> LsMercaderia { get; set; }
    }
}
