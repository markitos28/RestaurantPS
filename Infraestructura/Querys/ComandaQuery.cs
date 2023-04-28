using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;
using SlnManagerText;

namespace Infraestructura.Querys
{
    public class ComandaQuery: IComandaQuery
    {
        private readonly RestoDbContext _context;

        public ComandaQuery(RestoDbContext context)
        {
            _context = context;
        }


        public List<Comanda> SelectComanda()
        {
            try
            {
                var lista = (from lsc in _context.Comanda
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

        /*
         La funcion se utiliza para identificar si existe el identificador unico dentro de la tabla Comanda
        En caso de arrojar alguna excepcion, se identifica con un "mensaje" para poder informarlo.
         */
        public (string mensaje ,Task<bool> resultado) ComandaExist(Guid comandaId)
        {
            try
            {
                
                var find = (from c in _context.Comanda
                            where c.ComandaId == comandaId
                            select c.ComandaId).FirstOrDefault();
                if (find.Equals(Guid.Empty))
                {
                    return ("OK",Task.FromResult(false));
                }
                else
                {
                    return ("OK", Task.FromResult(true));
                }
            }
            catch(InvalidOperationException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo una excepcion 'InvalidOperationException' con error: ", ex.Message, " del archivo ", this.GetType()));
                }
                return ("Error: Operacion invalida",Task.FromResult(true));
            }
            catch (Exception ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return ("Error: Ha ocurrido una excepcion", Task.FromResult(true));
            }
        }
    }
}
