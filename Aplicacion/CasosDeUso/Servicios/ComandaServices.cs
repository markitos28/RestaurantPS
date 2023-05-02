using Aplicacion.Interfaces.Querys;
using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Dominio.Entidades;
using System.ComponentModel.Design;
using Aplicacion.Ayudantes;

namespace Aplicacion.CasosDeUso.Servicios
{
    public class ComandaServices : IComandaServices
    {
        private readonly IComandaQuery _queryComanda;
        private readonly IComandaCommand _commandComanda;
        private readonly IComandaMercaderiaQuery _queryComandaMercaderia;
        private readonly IComandaMercaderiaCommand _commandComandaMercaderia;
        private readonly IMercaderiaQuery _queryMercaderia;
        private readonly IFormaEntregaQuery _queryFormaEntrega;
        public ComandaServices(IComandaQuery queryComanda, IComandaCommand commandComanda, IComandaMercaderiaQuery queryComandaMercaderia, IMercaderiaQuery queryMercaderia, IFormaEntregaQuery queryFormaEntrega, IComandaMercaderiaCommand commandComandaMercaderia)
        {
            _queryComanda = queryComanda;
            _commandComanda = commandComanda;
            _queryComandaMercaderia = queryComandaMercaderia;
            _queryMercaderia = queryMercaderia;
            _queryFormaEntrega = queryFormaEntrega;
            _commandComandaMercaderia = commandComandaMercaderia;

        }
        public Task<ComandaDetalleResponse> GetComanda(Guid comandaId)
        {
            ComandaDetalleResponse comandaDetalleResponse = new ComandaDetalleResponse();
            var comanda = _queryComanda.SelectComanda(comandaId);
            var comandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comandaId);

            if(comanda != null && comandaMercaderia != null)
            {
                foreach (ComandaMercaderia cm in comandaMercaderia)
                {
                    var mercaderia = _queryMercaderia.SelectMercaderia(cm.MercaderiaId);
                    comandaDetalleResponse.Mercaderias.Add(new MercaderiaDTO(){
                        MercaderiaId= mercaderia.MercaderiaId,
                        Nombre= mercaderia.Nombre,
                        TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                        Precio = mercaderia.Precio,
                        Ingredientes = mercaderia.Ingredientes,
                        Preparacion = mercaderia.Preparacion,
                        Imagen = mercaderia.Imagen
                    });
                }
                comandaDetalleResponse.ComandaId = comanda.ComandaId;
                var formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId);
                comandaDetalleResponse.FormaEntrega = new FormaEntregaDTO()
                {
                    FormaEntregaId= formaEntrega.FormaEntregaId,
                    Descripcion = formaEntrega.Descripcion
                };
                comandaDetalleResponse.PrecioTotal= comanda.PrecioTotal;
                comandaDetalleResponse.Fecha = comanda.Fecha;

                return Task.FromResult(comandaDetalleResponse);
            }
            return null;
        }

        public Task<List<ComandaDetalleResponse>> GetComandasDetalle(DateTime fecha)
        {
            var comandas = _queryComanda.SelectComandas(fecha);
            
            if (comandas != null)
            {
                List<ComandaDetalleResponse> listaResponse = new List<ComandaDetalleResponse>();
                foreach (Comanda comanda in comandas)
                {
                    var comandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comanda.ComandaId);
                    ComandaDetalleResponse comandaDetalleResponse = new ComandaDetalleResponse();

                    foreach (ComandaMercaderia cm in comandaMercaderia)
                    {
                        var mercaderia = _queryMercaderia.SelectMercaderia(cm.MercaderiaId);
                        comandaDetalleResponse.Mercaderias.Add(new MercaderiaDTO()
                        {
                            MercaderiaId = mercaderia.MercaderiaId,
                            Nombre = mercaderia.Nombre,
                            TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                            Precio = mercaderia.Precio,
                            Ingredientes = mercaderia.Ingredientes,
                            Preparacion = mercaderia.Preparacion,
                            Imagen = mercaderia.Imagen
                        });
                    }
                    comandaDetalleResponse.ComandaId = comanda.ComandaId;
                    var formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId);
                    comandaDetalleResponse.FormaEntrega = new FormaEntregaDTO()
                    {
                        FormaEntregaId = formaEntrega.FormaEntregaId,
                        Descripcion = formaEntrega.Descripcion
                    };
                    comandaDetalleResponse.PrecioTotal = comanda.PrecioTotal;
                    comandaDetalleResponse.Fecha = comanda.Fecha;

                    listaResponse.Add(comandaDetalleResponse);
                }
                return Task.FromResult(listaResponse);
            }
            return null;
        }

        public Task<bool> InsertComanda(List<int> listaProductos, int formaEntrega)
        {
            var newComandaId = new GenerarIdentificador(_queryComanda).GenerarIdComanda();
            Comanda insertComanda = new Comanda()
            {
                ComandaId= newComandaId.Result,
                FormaEntregaId= formaEntrega,
                PrecioTotal=0,
                Fecha = DateTime.Now
            };

            foreach(int mercaderiaId in listaProductos)
            {
                var mercaderia = _queryMercaderia.SelectMercaderia(mercaderiaId);
                _commandComandaMercaderia.InsertComandaMercaderia(new ComandaMercaderia()
                {
                    MercaderiaId= mercaderiaId,
                    ComandaId= newComandaId.Result
                });
                insertComanda.PrecioTotal += mercaderia.Precio;
            }

            return _commandComanda.InsertComanda(insertComanda);
        }
    }
}
