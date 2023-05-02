using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IComandaQuery
    {
        public List<Comanda> SelectComanda();
        public List<Comanda> SelectComandas(DateTime fecha);
        public Comanda SelectComanda(Guid comandaId);
        public (string mensaje, Task<bool> resultado) ComandaExist(Guid comandaId);
    }
}
