namespace Dominio.DTOs
{
    public class MercaderiaResponse2
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMercaderiaDTO Tipo { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }
    }
}
