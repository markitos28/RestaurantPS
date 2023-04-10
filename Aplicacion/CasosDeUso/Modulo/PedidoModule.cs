using Aplicacion.Interfaces.Querys;
using Dominio.DTOs;
using Dominio.Entidades;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class PedidoModule
    {
        private readonly IComandaQuery _queryComanda;
        private readonly IComandaMercaderiaQuery _queryComandaMercaderia;
        private readonly IMercaderiaQuery _queryMercaderia;
        private readonly IFormaEntregaQuery _queryFormaEntrega;

        public PedidoModule(IComandaQuery comandaQuery, IComandaMercaderiaQuery comandaMercaderiaQuery, IMercaderiaQuery mercadoQuery, IFormaEntregaQuery formaEntregaQuery)
        {
            _queryComanda = comandaQuery;
            _queryComandaMercaderia = comandaMercaderiaQuery;
            _queryMercaderia = mercadoQuery;
            _queryFormaEntrega = formaEntregaQuery;
        }

        public List<PedidoDTO> ListarPedidos()
        {
            List<PedidoDTO> pedidoDTOs = new List<PedidoDTO>();

            var lsComandas = _queryComanda.SelectComanda();
            foreach (var comanda in lsComandas)
            {
                FormaEntrega formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId); 
                var lsComandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comanda.ComandaId);
                foreach(var comandaMercaderia in lsComandaMercaderia)
                {
                    Mercaderia mercaderia = _queryMercaderia.SelectMercaderia(comandaMercaderia.MercaderiaId);
                    PedidoDTO pedido = new PedidoDTO
                    {
                        ComandaId= comanda.ComandaId,
                        FechaComanda= comanda.Fecha,
                        DescripcionEntrega= formaEntrega.Descripcion,
                        NombreMercaderia= mercaderia.Nombre,
                        PrecioMercaderia = mercaderia.Precio,
                        IngredientesMercaderia = mercaderia.Ingredientes,
                        PreparacionMercaderia = mercaderia.Preparacion
                    };
                    pedidoDTOs.Add(pedido);
                }
            }

            return pedidoDTOs;
        }

    }
}
