namespace Dominio.Entidades
{
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }
        public string Descripcion { get; set; }
        public List<Mercaderia> LsMercaderia { get; set; }
    }
}
