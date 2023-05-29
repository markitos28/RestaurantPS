using Aplicacion.Interfaces.Querys;
using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Dominio.Entidades;

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
        public async Task<ComandaResponse> GetComanda(Guid comandaId)
        {
            ComandaResponse comandaResponse = new ComandaResponse();
            var comanda = _queryComanda.SelectComanda(comandaId);
            var comandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comandaId);
            comandaResponse.Mercaderias = new List<MercaderiaComandaResponse>();
            if(comanda != null && comandaMercaderia != null)
            {
                foreach (ComandaMercaderia cm in comandaMercaderia)
                {
                    var mercaderia = await _queryMercaderia.SelectMercaderia(cm.MercaderiaId);
                    comandaResponse.Mercaderias.Add(new MercaderiaComandaResponse()
                    {
                        Id= mercaderia.MercaderiaId,
                        Nombre= mercaderia.Nombre,
                        Precio= mercaderia.Precio
                    });
                }
                comandaResponse.Id = comanda.ComandaId;
                var formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId);
                comandaResponse.FormaEntrega = new FormaEntregaDTO()
                {
                    Id = formaEntrega.FormaEntregaId,
                    Descripcion = formaEntrega.Descripcion
                };

                comandaResponse.Total = comanda.PrecioTotal;
                comandaResponse.Fecha = comanda.Fecha;

                return comandaResponse;
            }
            return null;
        }

        public async Task<List<ComandaResponse>> GetComandasDetalle(DateTime fecha)
        {
            var comandas = _queryComanda.SelectComandas(fecha);
            
            if (comandas != null)
            {
                List<ComandaResponse> listaResponse = new List<ComandaResponse>();
                foreach (Comanda comanda in comandas)
                {
                    var comandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comanda.ComandaId);
                    ComandaResponse comandaResponse = new ComandaResponse();
                    comandaResponse.Mercaderias = new List<MercaderiaComandaResponse>();

                    foreach (ComandaMercaderia cm in comandaMercaderia)
                    {
                        var mercaderia = await _queryMercaderia.SelectMercaderia(cm.MercaderiaId);
                        comandaResponse.Mercaderias.Add(new MercaderiaComandaResponse()
                        {
                            Id = mercaderia.MercaderiaId,
                            Nombre = mercaderia.Nombre,
                            Precio = mercaderia.Precio,
                        });
                    }
                    comandaResponse.Id = comanda.ComandaId;
                    var formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId);
                    comandaResponse.FormaEntrega = new FormaEntregaDTO()
                    {
                        Id = formaEntrega.FormaEntregaId,
                        Descripcion = formaEntrega.Descripcion
                    };
                    comandaResponse.Total = comanda.PrecioTotal;
                    comandaResponse.Fecha = comanda.Fecha;

                    listaResponse.Add(comandaResponse);
                }
                return listaResponse;
            }
            return null;
        }

        public async Task<List<ComandaResponse>> GetComandasDetalleAll()
        {
            List<ComandaResponse> listaComandaResponse = new List<ComandaResponse>();
            var comandas = _queryComanda.SelectComanda();

            foreach (var comanda in comandas)
            {
                ComandaResponse comandaResponse = new ComandaResponse();
                var comandaMercaderia = _queryComandaMercaderia.SelectComandaMercaderia(comanda.ComandaId);
                comandaResponse.Mercaderias = new List<MercaderiaComandaResponse>();

                if (comandaMercaderia != null)
                {
                    foreach (ComandaMercaderia cm in comandaMercaderia)
                    {
                        var mercaderia = await _queryMercaderia.SelectMercaderia(cm.MercaderiaId);
                        comandaResponse.Mercaderias.Add(new MercaderiaComandaResponse()
                        {
                            Id = mercaderia.MercaderiaId,
                            Nombre = mercaderia.Nombre,
                            Precio = mercaderia.Precio
                        });
                    }
                    comandaResponse.Id = comanda.ComandaId;
                    var formaEntrega = _queryFormaEntrega.GetFormaEntrega(comanda.FormaEntregaId);
                    comandaResponse.FormaEntrega = new FormaEntregaDTO()
                    {
                        Id = formaEntrega.FormaEntregaId,
                        Descripcion = formaEntrega.Descripcion
                    };

                    comandaResponse.Total = comanda.PrecioTotal;
                    comandaResponse.Fecha = comanda.Fecha;

                    listaComandaResponse.Add(comandaResponse);
                }
            }
            return listaComandaResponse;
        }

        public  async Task<(ComandaResponse? response, string error)> InsertComanda(List<int> listaProductos, int formaEntrega)
        {
            DateTime fechaInsert = DateTime.Now;
            ComandaResponse response = new ComandaResponse();
            response.Mercaderias = new List<MercaderiaComandaResponse>();
            Comanda insertComanda = new Comanda()
            {
                FormaEntregaId= formaEntrega,
                PrecioTotal=0,
                Fecha = fechaInsert
            };

            foreach (int mercaderiaId in listaProductos)
            {
                var mercaderia = await _queryMercaderia.SelectMercaderia(mercaderiaId);

                if(mercaderia == null) { return (null, $"Una de las mercaderias que se intento insertar no existe. La misma tiene por ID = {mercaderiaId}"); }

                response.Mercaderias.Add(new MercaderiaComandaResponse()
                {
                    Id= mercaderia.MercaderiaId,
                    Nombre = mercaderia.Nombre,
                    Precio = mercaderia.Precio
                });
                insertComanda.PrecioTotal += mercaderia.Precio;
            }
            response.Total = insertComanda.PrecioTotal;

            var getFormaEntrega = _queryFormaEntrega.GetFormaEntrega(formaEntrega);
            if (getFormaEntrega == null) { return (null, $"La forma de entrega no existe. El Id es : {formaEntrega}"); }
            response.FormaEntrega = new FormaEntregaDTO() 
            { 
                Id= getFormaEntrega.FormaEntregaId, 
                Descripcion= getFormaEntrega.Descripcion 
            };
            response.Fecha = fechaInsert;
            var insert = await _commandComanda.InsertComanda(insertComanda);
            response.Id = insert.ComandaId;
            foreach (int mercaderiaId in listaProductos)
            {
                await _commandComandaMercaderia.InsertComandaMercaderia(new ComandaMercaderia()
                {
                    MercaderiaId = mercaderiaId,
                    ComandaId = insert.ComandaId
                });
            }

            return (response,"OK");
        }
    }
}
