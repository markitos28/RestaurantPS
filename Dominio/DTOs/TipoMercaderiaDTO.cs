namespace Dominio.DTOs
{
    public class TipoMercaderiaDTO
    {
        public int TipoMercaderiaId { get; set; }
        public string Descripcion { get; set; }
        public List<MercaderiaDTO> LsMercaderia { get; set; }
    }
}
