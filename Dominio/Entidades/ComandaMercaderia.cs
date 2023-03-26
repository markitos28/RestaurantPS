namespace Dominio.Entidades
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; }
        public int MercaderiaId { get; set; }
        public Guid ComandaId { get; set; }

    }
}
