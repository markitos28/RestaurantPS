using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface ITipoMercaderiaQuery
    {
        Task<TipoMercaderia> GetTipoMercaderia(int id);
    }
}
