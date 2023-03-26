namespace Dominio.DTOs
{
    public class FormaEntregaDTO
    {
        public int FormaEntregaId { get; set; }
        public string Descripcion { get; set; }
        public List<ComandaDTO> LsComanda { get; set; }

    }
}
