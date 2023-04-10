using Dominio.Entidades;

namespace Aplicacion.Interfaces.Comandos
{
    public interface IComandaMercaderiaCommand
    {
        Task<bool> InsertComandaMercaderia(ComandaMercaderia objComandaMercaderia);
    }
}
