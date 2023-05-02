using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs
{
    public class ComandaDetalleResponse
    {
        public Guid ComandaId { get; set; }
        public List<MercaderiaDTO> Mercaderias { get; set; }
        public FormaEntregaDTO FormaEntrega { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
    }
}
