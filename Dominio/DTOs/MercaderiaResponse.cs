namespace Dominio.DTOs
{
    public class MercaderiaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public TipoMercaderiaDTO Tipo { get; set; }
        public string Imagen { get; set; }

    }
}
