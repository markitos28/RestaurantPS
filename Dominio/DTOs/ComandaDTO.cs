namespace Dominio.DTOs
{
    public class ComandaDTO
    {
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<ComandaMercaderiaDTO> LsComandaMercaderia { get; set; }
    }
}
