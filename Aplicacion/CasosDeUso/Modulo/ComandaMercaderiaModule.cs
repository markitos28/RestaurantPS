using Aplicacion.Interfaces.Comandos;
using Dominio.DTOs;
using Dominio.Entidades;

namespace Aplicacion.CasosDeUso.Modulo
{
    public class ComandaMercaderiaModule
    {
        readonly IComandaMercaderiaCommand _command;

        public ComandaMercaderiaModule(IComandaMercaderiaCommand command)
        {
            _command = command;
        }

        public bool InsertarComandaMercaderia(ComandaMercaderiaDTO objComandaMercaderia)
        {
            ComandaMercaderia cm = new ComandaMercaderia
            {
                MercaderiaId = objComandaMercaderia.MercaderiaId,
                ComandaId = objComandaMercaderia.ComandaId
            };
            _command.InsertComandaMercaderia(cm);
            return true;
        }
    }
}
