using Dominio.Entidades;

namespace Aplicacion.Interfaces.Comandos
{
    public interface IComandaCommand
    {
        Task<Comanda> InsertComanda(Comanda objComanda);
    }
}
