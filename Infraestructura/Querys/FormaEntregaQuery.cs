using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using SlnManagerText;

namespace Infraestructura.Querys
{
    public class FormaEntregaQuery:IFormaEntregaQuery
    {
        private readonly RestoDbContext _context;

        public FormaEntregaQuery(RestoDbContext context)
        {
            _context = context;
        }

        public List<FormaEntrega> SelectFormaEntrega()
        {
            try
            {
                var lsFormaEntregas = (from fe in _context.FormaEntrega
                                       select fe).ToList();
                return lsFormaEntregas;
            }
            catch(ArgumentNullException ex)
            {
                var log= new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if(log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return null;
            }
            catch (Exception ex)
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
