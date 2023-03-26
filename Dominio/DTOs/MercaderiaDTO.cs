﻿namespace Dominio.DTOs
{
    public class MercaderiaDTO
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }
        public List<ComandaMercaderiaDTO> LsComandaMercaderia { get; set; }

    }
}
