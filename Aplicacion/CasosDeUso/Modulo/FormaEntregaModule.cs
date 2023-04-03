using Dominio.Entidades;
using Aplicacion.Interfaces.Querys;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class FormaEntregaModule
    {
        readonly IFormaEntregaQuery _query;

        public FormaEntregaModule (IFormaEntregaQuery query)
        {
            _query = query;
        }

        public List<FormaEntrega> ListarFormaEntrega()
        {
            var lsFormaEntrega = _query.SelectFormaEntrega();
            return lsFormaEntrega;
        }
    }
}
