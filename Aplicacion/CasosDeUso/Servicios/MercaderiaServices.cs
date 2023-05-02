using Aplicacion.Interfaces.Querys;
using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Dominio.Entidades;


namespace Aplicacion.CasosDeUso.Servicios
{
    public class MercaderiaServices : IMercaderiaServices
    {
        readonly private IMercaderiaCommand _command;
        readonly private IMercaderiaQuery _query;
        readonly private IComandaMercaderiaQuery _cmQuery;

        public MercaderiaServices(IMercaderiaCommand command, IMercaderiaQuery query, IComandaMercaderiaQuery cmQuery)
        {
            _command = command;
            _query = query;
            _cmQuery = cmQuery;
        }

        public Task<MercaderiaDTO> AddMercaderia(MercaderiaDTO mercaderia)
        {
            var insert = _command.InsertMercaderia(mercaderia);
            return insert;
            
        }

        public Task<(bool status, int returnCode)> DeleteMercaderia(int mercaderiaId)
        {
            var dependencia = _cmQuery.ExisteMercaderiaEnComanda(mercaderiaId);
            if (!dependencia.exist && dependencia.returnCode.Equals(0))
            {
                var delete = _command.DeleteMercaderia(mercaderiaId);
                return Task.FromResult((delete.Result, dependencia.returnCode));
            }
            return Task.FromResult((false, dependencia.returnCode));
        }

        public Task<MercaderiaDTO> GetMercaderia(int mercaderiaId)
        {
            var select = _query.SelectMercaderia(mercaderiaId);
            if(select != null)
            {
                var mappMercaderia = new MercaderiaDTO()
                {
                    MercaderiaId = select.MercaderiaId,
                    Nombre = select.Nombre,
                    TipoMercaderiaId = select.TipoMercaderiaId,
                    Precio = select.Precio,
                    Ingredientes = select.Ingredientes,
                    Preparacion = select.Preparacion,
                    Imagen = select.Imagen
                };

                return Task.FromResult(mappMercaderia);
            }
            return null;
           
        }

        public Task<MercaderiaDTO> GetMercaderia(string nombre)
        {
            var select = _query.SelectMercaderia(nombre);
            if (select != null)
            {
                var mappMercaderia = new MercaderiaDTO()
                {
                    MercaderiaId = select.MercaderiaId,
                    Nombre = select.Nombre,
                    TipoMercaderiaId = select.TipoMercaderiaId,
                    Precio = select.Precio,
                    Ingredientes = select.Ingredientes,
                    Preparacion = select.Preparacion,
                    Imagen = select.Imagen
                };

                return Task.FromResult(mappMercaderia);
            }
            return null;
        }

        public Task<List<MercaderiaDTO>> GetMercaderias()
        {
            
            var mercaderias = _query.SelectListaMercaderia();
            if(mercaderias != null)
            {
                List<MercaderiaDTO> list = new List<MercaderiaDTO>();
                foreach (Mercaderia mercaderia in mercaderias)
                {
                    list.Add(new MercaderiaDTO()
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
                return Task.FromResult(list);
            }
            return null;
            
        }

        public Task<MercaderiaDTO> UpdateMercaderia(MercaderiaDTO mercaderia)
        {
            var update = _command.UpdateMercaderia(mercaderia);
            return update;
        }

        public Task<List<MercaderiaDTO>> GetListMercaderia(int tipo, string nombre, string orden)
        {
            List<MercaderiaDTO> response = new List<MercaderiaDTO>(); ;
            List<Mercaderia> query ;
            if (!string.IsNullOrEmpty(nombre) && tipo != -1)
            {
                query = _query.SelectMercaderia(tipo, nombre);
            }
            else if (!string.IsNullOrEmpty(nombre) && tipo == -1)
            {
                query = _query.SelectLikeMercaderia(nombre);
            }
            else
            {
                query = _query.SelectListaMercaderia(tipo);
            }
            if(query != null)
            {
                foreach (Mercaderia puntero in query)
                {
                    response.Add(new MercaderiaDTO
                    {
                        MercaderiaId = puntero.MercaderiaId,
                        Nombre = puntero.Nombre,
                        TipoMercaderiaId = puntero.TipoMercaderiaId,
                        Precio = puntero.Precio,
                        Ingredientes = puntero.Ingredientes,
                        Preparacion = puntero.Preparacion,
                        Imagen = puntero.Imagen

                    });
                }
            }
            
            if (orden.Equals("ASC"))
            {
                return Task.FromResult(response.OrderBy(o => o.Precio).ToList<MercaderiaDTO>());
            }
            else
            {
                return Task.FromResult(response.OrderByDescending(o => o.Precio).ToList<MercaderiaDTO>());
            }

        }

    }
}
