using Aplicacion.Interfaces.Querys;

namespace Aplicacion.Ayudantes
{
    public class GenerarIdentificador
    { 
        readonly IComandaQuery _queryComanda;
        readonly IComandaMercaderiaQuery _queryComandaMercaderia;
        public GenerarIdentificador(IComandaQuery query)
        {
            _queryComanda = query;
        }

        public GenerarIdentificador(IComandaMercaderiaQuery query)
        {
            _queryComandaMercaderia = query;
        }

        public async Task<Guid> GenerarIdComanda()
        {
            
            Guid guid = Guid.NewGuid();
            var existe = _queryComanda.ComandaExist(guid);
            while (existe.resultado.Result)
            {
                guid = Guid.NewGuid();
                existe = _queryComanda.ComandaExist(guid);
            }
            return guid;
        }

    }
}
