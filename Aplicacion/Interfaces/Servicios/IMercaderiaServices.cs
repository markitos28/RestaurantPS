using Dominio.DTOs;

namespace Aplicacion.Interfaces.Servicios
{
    public interface IMercaderiaServices
    {
        Task<(MercaderiaResponse2 response, string error)> AddMercaderia(MercaderiaRequest mercaderia);
        Task<(MercaderiaResponse2 response, string description, int error)> UpdateMercaderia(int id, MercaderiaRequest mercaderia);
        Task<(MercaderiaResponse2 response, string status)> DeleteMercaderia(int mercaderiaId);
        Task<MercaderiaResponse2> GetMercaderia(int mercaderiaId);
        Task<List<MercaderiaResponse>> GetMercaderias();
        Task<MercaderiaDTO> GetMercaderia(string nombre);
        Task<List<MercaderiaResponse>> GetListMercaderia(int tipo, string nombre, string orden);


    }
}
