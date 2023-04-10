using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IComandaQuery
    {
        public List<Comanda> SelectComanda();
        public (string mensaje, Task<bool> resultado) ComandaExist(Guid comandaId);
    }
}
