using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IFormaEntregaQuery
    {
        List<FormaEntrega> SelectFormaEntrega();
        FormaEntrega GetFormaEntrega(int formaEntregaId);
    }
}
