using Dominio.DTOs;

namespace Aplicacion.Interfaces.Servicios
{
    public interface IMercaderiaServices
    {
        Task<MercaderiaDTO> AddMercaderia(MercaderiaDTO mercaderia);
        Task<MercaderiaDTO> UpdateMercaderia(MercaderiaDTO mercaderia);
        Task<(bool status, int returnCode)> DeleteMercaderia(int mercaderiaId);
        Task<MercaderiaDTO> GetMercaderia(int mercaderiaId);
        Task<List<MercaderiaDTO>> GetMercaderias();
        Task<MercaderiaDTO> GetMercaderia(string nombre);
        Task<List<MercaderiaDTO>> GetListMercaderia(int tipo, string nombre, string orden);


    }
}
