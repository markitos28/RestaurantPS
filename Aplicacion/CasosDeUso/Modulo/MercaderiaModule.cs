using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class MercaderiaModule
    {
        readonly IMercaderiaQuery _query;
        public MercaderiaModule(IMercaderiaQuery query)
        {
            _query = query;
        }

        public List<Mercaderia> ListarMercaderia()
        {
            var listaMercaderia = _query.SelectListaMercaderia();
            return listaMercaderia;
        }
    }
}
