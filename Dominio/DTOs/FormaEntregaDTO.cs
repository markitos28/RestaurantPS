using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs
{
    public class FormaEntregaDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        

    }
}
