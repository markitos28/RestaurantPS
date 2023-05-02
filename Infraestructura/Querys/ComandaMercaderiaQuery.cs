using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using SlnManagerText;
using System.Runtime;

namespace Infraestructura.Querys
{
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private readonly RestoDbContext _context;
        public ComandaMercaderiaQuery(RestoDbContext context)
        {
            _context = context;
        }

        public List<ComandaMercaderia> SelectComandaMercaderia()
        {
            try
            {
                var lista = (from lsc in _context.ComandaMercaderia
                             select lsc).ToList();
                return lista;
            }
            catch (ArgumentNullException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
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

        public List<ComandaMercaderia> SelectComandaMercaderia(Guid comandaId)
        {
            try
            {
                var lista = (from lsc in _context.ComandaMercaderia
                             where lsc.ComandaId==comandaId
                             select lsc).ToList();
                return lista;
            }
            catch (ArgumentNullException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
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

        public List<ComandaMercaderia> SelectComandaMercaderia(int mercaderiaId)
        {
            try
            {
                var lista = (from lsc in _context.ComandaMercaderia
                             where lsc.MercaderiaId == mercaderiaId
                             select lsc).ToList();
                return lista;
            }
            catch (ArgumentNullException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
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

        public (bool exist,int returnCode) ExisteMercaderiaEnComanda(int mercaderiaId)
        {
            try
            {
                var existe = (from lsc in _context.ComandaMercaderia
                             where lsc.MercaderiaId == mercaderiaId
                             select lsc).First();
                if(existe != null)
                {
                    return (true,0);
                }
                return (false,0);
                
            }
            catch (ArgumentNullException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return (false, -1000);
            }
            catch (Exception ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return (false, -1001);
            }
        }
    }
}
