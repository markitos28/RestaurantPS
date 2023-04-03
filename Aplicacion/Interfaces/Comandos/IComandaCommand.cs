using Dominio.Entidades;

namespace Aplicacion.Interfaces.Comandos
{
    public interface IComandaCommand
    {
        Task<bool> InsertComanda(Comanda objComanda);
    }
}
