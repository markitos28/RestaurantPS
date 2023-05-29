namespace Dominio.DTOs
{
    public class ComandaResponse
    {
        public Guid Id { get; set; }
        public List<MercaderiaComandaResponse> Mercaderias { get; set; }
        public FormaEntregaDTO FormaEntrega { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
