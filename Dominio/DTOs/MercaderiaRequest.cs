﻿namespace Dominio.DTOs
{
    public class MercaderiaRequest
    {
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacion { get; set; }
        public string Imagen { get; set; }
    }
}
