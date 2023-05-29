using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class MercaderiaDTO
    {
        [Key]
        public int MercaderiaId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }
        [StringLength(255)]
        public string Ingredientes { get; set; }
        [StringLength(255)]
        public string Preparacion { get; set; }
        [StringLength(255)]
        public string Imagen { get; set; }

    }
}
