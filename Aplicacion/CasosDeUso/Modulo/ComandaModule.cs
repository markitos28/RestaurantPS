using Aplicacion.Interfaces.Comandos;
using Aplicacion.Interfaces.Querys;
using Dominio.DTOs;
using Dominio.Entidades;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class ComandaModule
    {
        readonly IComandaCommand _command;
        readonly IComandaQuery _query;

        public ComandaModule(IComandaCommand command, IComandaQuery query)
        {
            _command = command;
            _query = query;
        }

        public Task<Comanda> InsertarComanda (ComandaDTO objComanda)
        {
            Comanda comanda = new Comanda
            {
                FormaEntregaId = objComanda.FormaEntregaId,
                PrecioTotal= objComanda.PrecioTotal,
                Fecha= objComanda.Fecha
            };
            var operacion = _command.InsertComanda(comanda);         
            return operacion;
        }
    }
}
