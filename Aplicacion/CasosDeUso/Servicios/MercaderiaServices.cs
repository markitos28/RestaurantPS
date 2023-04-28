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

        public MercaderiaServices(IMercaderiaCommand command, IMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public Task<MercaderiaDTO> AddMercaderia(MercaderiaDTO mercaderia)
        {
            var insert = _command.InsertMercaderia(mercaderia);
            return insert;
            
        }

        public Task<bool> DeleteMercaderia(int mercaderiaId)
        {
            var delete = _command.DeleteMercaderia(mercaderiaId);
            return delete;
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

        public Task<List<MercaderiaDTO>> GetMercaderia()
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

    }
}
