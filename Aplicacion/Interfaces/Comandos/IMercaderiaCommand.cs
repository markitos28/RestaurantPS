using Dominio.Entidades;
using Dominio.DTOs;

namespace Aplicacion.Interfaces.Comandos
{
    public interface IMercaderiaCommand
    {
        Task<Mercaderia> InsertMercaderia(MercaderiaDTO mercaderia);
        Task<bool> DeleteMercaderia(int id);
        Task<Mercaderia> UpdateMercaderia(int id, MercaderiaRequest mercaderia);

    }
}
