using Dominio.DTOs;

namespace Aplicacion.Interfaces.Servicios
{
    public interface IMercaderiaServices
    {
        Task<MercaderiaDTO> AddMercaderia(MercaderiaDTO mercaderia);
        Task<MercaderiaDTO> UpdateMercaderia(MercaderiaDTO mercaderia);
        Task<bool> DeleteMercaderia(int mercaderiaId);
        Task<MercaderiaDTO> GetMercaderia(int mercaderiaId);
        Task<List<MercaderiaDTO>> GetMercaderia();


    }
}
