using Dominio.DTOs;

namespace Aplicacion.Interfaces.Servicios
{
    public interface IComandaServices
    {
        public Task<bool> InsertComanda(List<int> listaProductos, int fromaEntrega);
        public Task<ComandaDetalleResponse> GetComanda(Guid comandaId);
        public Task<List<ComandaDetalleResponse>> GetComandasDetalle(DateTime fecha);

    }
}
