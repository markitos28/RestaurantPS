using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using Aplicacion.Interfaces;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class MercaderiaModule
    {
        readonly IMercaderiaCommand _command;
        readonly IMercaderiaQuery _query;

        public MercaderiaModule(IMercaderiaCommand command, IMercaderiaQuery query)
        {
            _command = command;
            _query = query;
        }

        public List<Mercaderia> ListarMercaderia()
        {
            var listaMercaderia = _query.SelectMercaderia();
            return listaMercaderia;
        }
    }
}
