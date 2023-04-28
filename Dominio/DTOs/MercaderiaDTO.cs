using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class MercaderiaDTO
    {
        [Key]
        [Required]
        public int MercaderiaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public int TipoMercaderiaId { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        [StringLength(255)]
        public string Ingredientes { get; set; }
        [Required]
        [StringLength(255)]
        public string Preparacion { get; set; }
        [Required]
        [StringLength(255)]
        public string Imagen { get; set; }

    }
}
