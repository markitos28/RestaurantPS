using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IComandaMercaderiaQuery
    {
        public List<ComandaMercaderia> SelectComandaMercaderia();
        public List<ComandaMercaderia> SelectComandaMercaderia(Guid comandaId);
        public List<ComandaMercaderia> SelectComandaMercaderia(int mercaderiaId);
        public Task<bool> ExisteMercaderiaEnComanda(int mercaderiaId);
    }
}
