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
        readonly private ITipoMercaderiaQuery _queryTipoMercaderia;
        readonly private IComandaMercaderiaQuery _cmQuery;

        public MercaderiaServices(IMercaderiaCommand command, IMercaderiaQuery query, IComandaMercaderiaQuery cmQuery, ITipoMercaderiaQuery queryTipoMercaderia)
        {
            _command = command;
            _query = query;
            _cmQuery = cmQuery;
            _queryTipoMercaderia = queryTipoMercaderia;
        }

        public async Task<(MercaderiaResponse2 response, string error)> AddMercaderia(MercaderiaRequest mercaderia)
        {
            var tipoMercaderia= await _queryTipoMercaderia.GetTipoMercaderia(mercaderia.Tipo);
            if(tipoMercaderia == null)
            {
                return (null, $"El tipo de mercaderia '{mercaderia.Tipo}' no es valido o no existe. Por favor, primero inserte el tipo de mercaderia o ingrese un tipo de mercaderia valido y vuelva a intentarlo");
            }

            MercaderiaDTO mapMercaderia = new MercaderiaDTO()
            {
                Nombre = mercaderia.Nombre,
                TipoMercaderiaId = mercaderia.Tipo,
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen
            };
            var insert = await _command.InsertMercaderia(mapMercaderia);
            var mappTipoMercaderia = new TipoMercaderiaDTO()
            {
                Id= tipoMercaderia.TipoMercaderiaId,
                Descripcion= tipoMercaderia.Descripcion
            };

            return (new MercaderiaResponse2()
            {
                Id= insert.MercaderiaId,
                Nombre= insert.Nombre,
                Precio=insert.Precio,
                Tipo = mappTipoMercaderia,
                Ingredientes= insert.Ingredientes, 
                Preparacion= insert.Preparacion,
                Imagen= insert.Imagen
            },"OK");
            
        }

        public async Task<(MercaderiaResponse2 response, string status)> DeleteMercaderia(int mercaderiaId)
        {
            var dependencia = await _cmQuery.ExisteMercaderiaEnComanda(mercaderiaId);
            if (dependencia)
            {
                return (null, "No se pudo eliminar la mercaderia porque depende de una comanda.");
            }
            var mercaderia = await _query.SelectMercaderia(mercaderiaId);

            var tipoMercaderia = await _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId);
            var mappTipoMercaderia = new TipoMercaderiaDTO()
            {
                Id = tipoMercaderia.TipoMercaderiaId,
                Descripcion = tipoMercaderia.Descripcion
            };

            var response = new MercaderiaResponse2()
            {
                Id= mercaderia.MercaderiaId,
                Nombre = mercaderia.Nombre,
                Tipo= mappTipoMercaderia,
                Precio= mercaderia.Precio,
                Ingredientes= mercaderia.Ingredientes,
                Preparacion= mercaderia.Preparacion,
                Imagen=mercaderia.Imagen
            };
            var delete = _command.DeleteMercaderia(mercaderiaId);
            return (response, "OK");
            
        }

        public async Task<MercaderiaResponse2> GetMercaderia(int mercaderiaId)
        {
            var select = await _query.SelectMercaderia(mercaderiaId);
            if(select != null)
            {
                var tipoMercaderia = await _queryTipoMercaderia.GetTipoMercaderia(select.TipoMercaderiaId);
                TipoMercaderiaDTO mapperTipoMercaderia = new TipoMercaderiaDTO()
                {
                    Id = tipoMercaderia.TipoMercaderiaId,
                    Descripcion = tipoMercaderia.Descripcion
                };
                var mappMercaderia = new MercaderiaResponse2()
                {
                    Id = select.MercaderiaId,
                    Nombre = select.Nombre,
                    Tipo = mapperTipoMercaderia,
                    Precio = select.Precio,
                    Ingredientes = select.Ingredientes,
                    Preparacion = select.Preparacion,
                    Imagen = select.Imagen
                };

                return mappMercaderia;
            }
            return null;
           
        }

        public async Task<MercaderiaDTO> GetMercaderia(string nombre)
        {
            var select = await _query.SelectMercaderia(nombre);
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

                return mappMercaderia;
            }
            return null;
        }

        public async Task<List<MercaderiaResponse>> GetMercaderias()
        {
            
            var mercaderias = _query.SelectListaMercaderia();
            if(mercaderias != null)
            {
                List<MercaderiaResponse> list = new List<MercaderiaResponse>();
                foreach (Mercaderia mercaderia in mercaderias)
                {
                    var tipoMercaderia = await _queryTipoMercaderia.GetTipoMercaderia(mercaderia.TipoMercaderiaId);
                    var mappTipoMercaderia = new TipoMercaderiaDTO()
                    {
                        Id = tipoMercaderia.TipoMercaderiaId,
                        Descripcion = tipoMercaderia.Descripcion
                    };
                    list.Add(new MercaderiaResponse()
                    {
                        Id = mercaderia.MercaderiaId,
                        Nombre = mercaderia.Nombre,
                        Tipo = mappTipoMercaderia,
                        Precio = mercaderia.Precio,
                        Imagen = mercaderia.Imagen
                    });
                }
                return list;
            }
            return null;
            
        }

        public async Task<(MercaderiaResponse2 response, string description, int error)> UpdateMercaderia(int id, MercaderiaRequest mercaderia)
        {
            var bbddMercaderia = await _query.SelectMercaderia(id);
            var nombreExist = await _query.SelectMercaderia(mercaderia.Nombre);
            var tipoMercaderia = await _queryTipoMercaderia.GetTipoMercaderia(mercaderia.Tipo);
            if (bbddMercaderia == null)
            {
                return (null, $"La mercaderia con ID {id} que intenta modificar, no existe. Por favor intente con un ID valido.",404); 
            }
            if(nombreExist != null)
            {
                return (null, $"No se pueda modificar el nombre de la Mercaderia con ID {id} ya que ese nombre lo ocupa la Mercaderia con ID {nombreExist.MercaderiaId}. Por favor escoja otro nombre",409); 
            }
            if(tipoMercaderia == null && !mercaderia.Tipo.Equals(0))
            {
                return (null, $"El tipo de mercaderia {mercaderia.Tipo} que ingreso no existe o no es valido. Por favor primero inserte el tipo de mercaderia o ingrese uno valido",400); 
            }
            if(mercaderia.Precio <= 0)
            {
                return (null, $"El precio de la mercaderia ${mercaderia.Precio} que ingreso debe ser mayor a cero. Por favor ingrese un numero valido", 400);
            }

            var update = await _command.UpdateMercaderia(id,mercaderia);

            tipoMercaderia= await _queryTipoMercaderia.GetTipoMercaderia(update.TipoMercaderiaId);
            var mappTipoMercaderia = new TipoMercaderiaDTO()
            {
                Id = tipoMercaderia.TipoMercaderiaId,
                Descripcion = tipoMercaderia.Descripcion
            };

            return (new MercaderiaResponse2()
            {
                Id= update.MercaderiaId,
                Nombre= update.Nombre,
                Precio= update.Precio,
                Tipo= mappTipoMercaderia,
                Ingredientes = update.Ingredientes,
                Preparacion = update.Preparacion,
                Imagen = update.Imagen
            }, "OK", 200);
        }

        public async Task<List<MercaderiaResponse>> GetListMercaderia(int tipo, string nombre, string orden)
        {
            List<MercaderiaResponse> response = new List<MercaderiaResponse>();
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
                    var mapp = new MercaderiaResponse
                    {
                        Id = puntero.MercaderiaId,
                        Nombre = puntero.Nombre,
                        Precio = puntero.Precio,
                        Imagen = puntero.Imagen
                    };
                    var tipoMercaderia = await _queryTipoMercaderia.GetTipoMercaderia(puntero.TipoMercaderiaId);
                    mapp.Tipo = new TipoMercaderiaDTO()
                    {
                        Id= tipoMercaderia.TipoMercaderiaId,
                        Descripcion= tipoMercaderia.Descripcion
                    };
                    response.Add(mapp);
                }
            }
            
            if (orden.Equals("ASC"))
            {
                return  response.OrderBy(o => o.Precio).ToList<MercaderiaResponse>();
            }
            else
            {
                return response.OrderByDescending(o => o.Precio).ToList<MercaderiaResponse>();
            }

        }

    }
}
