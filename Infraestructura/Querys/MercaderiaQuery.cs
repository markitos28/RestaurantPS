using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using SlnManagerText;

namespace Infraestructura.Querys
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly RestoDbContext _context;

        public MercaderiaQuery(RestoDbContext context)
        {
            _context = context;
        }
        public List<Mercaderia> SelectMercaderia()
        {
            try
            {
                var mercaderias = (from m in _context.Mercaderia
                                   select m).ToList();
                return mercaderias;
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

        public Mercaderia SelectMercaderia(string nombre)
        {
            try
            {
                var mercaderia = (from m in _context.Mercaderia
                                  where m.Nombre == nombre
                                  select m).FirstOrDefault();
                return mercaderia;
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

        public List<Mercaderia> SelectLikeMercaderia(string nombre)
        {
            try
            {
                var mercaderias = (from m in _context.Mercaderia
                                  where m.Nombre.Contains(nombre)
                                  select m).ToList();
                return mercaderias;
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

        public List<Mercaderia> SelectMercaderia(int tipoMercaderia)
        {
            try
            {
                var mercaderias = (from m in _context.Mercaderia
                                   where m.TipoMercaderiaId == tipoMercaderia
                                   select m).ToList();
                return mercaderias;
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
    }
}
