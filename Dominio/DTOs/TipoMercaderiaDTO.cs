using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class TipoMercaderiaDTO
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
