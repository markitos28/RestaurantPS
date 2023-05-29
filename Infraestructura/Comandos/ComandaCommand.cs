using Aplicacion.Interfaces.Comandos;
using Dominio.Entidades;
using SlnManagerText;

namespace Infraestructura.Comandos
{
    public class ComandaCommand : IComandaCommand
    {
        private readonly RestoDbContext _context;

        public ComandaCommand(RestoDbContext context)
        {
            _context = context;
        }
        public async Task<Comanda> InsertComanda(Comanda objComanda)
        {
            try
            {
                if(objComanda != null)
                {
                    _context.Add(objComanda);
                    await _context.SaveChangesAsync();
                    return objComanda;
                }
                return null;
            }
            catch(Exception ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return null;
            }
        }
    }
}
