namespace Dominio.Entidades
{
    public class Comanda
    {
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public List<ComandaMercaderia> LsComandaMercaderia { get; set; }
        public FormaEntrega FKFormaEntrega { get; set; }
    }
}
