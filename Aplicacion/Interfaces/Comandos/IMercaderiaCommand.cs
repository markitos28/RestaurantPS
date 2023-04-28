using Dominio.DTOs;

namespace Aplicacion.Interfaces.Comandos
{
    public interface IMercaderiaCommand
    {
        Task<MercaderiaDTO> InsertMercaderia(MercaderiaDTO mercaderia);
        Task<bool> DeleteMercaderia(int id);
        Task<MercaderiaDTO> UpdateMercaderia(MercaderiaDTO mercaderia);

    }
}
