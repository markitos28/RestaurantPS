using Dominio.DTOs;

namespace Aplicacion.Interfaces.Servicios
{
    public interface IComandaServices
    {
        public Task<(ComandaResponse? response, string error)> InsertComanda(List<int> listaProductos, int fromaEntrega);
        public Task<ComandaResponse> GetComanda(Guid comandaId);
        public Task<List<ComandaResponse>> GetComandasDetalle(DateTime fecha);
        public Task<List<ComandaResponse>> GetComandasDetalleAll();

    }
}
