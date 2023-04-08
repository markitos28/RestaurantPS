using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class PedidoDTO
    {
        public Guid ComandaId { get; set; }
        public DateTime FechaComanda { get; set; }
        public string DescripcionEntrega { get; set; }
        public string NombreMercaderia { get; set; }
        public int PrecioMercaderia { get; set; }
        public string IngredientesMercaderia { get; set; }
        public string PreparacionMercaderia { get; set; }
        
    }
}
