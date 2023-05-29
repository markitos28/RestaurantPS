using Aplicacion.Interfaces.Comandos;
using Dominio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SlnManagerText;

namespace Infraestructura.Comandos
{
    public class ComandaMercaderiaCommand : IComandaMercaderiaCommand
    {
        private readonly RestoDbContext _context;

        public ComandaMercaderiaCommand(RestoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertComandaMercaderia(ComandaMercaderia objComandaMercaderia)
        {
            try
            {
                if (objComandaMercaderia != null)
                {
                    _context.Add(objComandaMercaderia);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;

                

            }
            catch(DbUpdateException ex )
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return false;
            }
            catch(SqlException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return false;
            }
            catch (Exception ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return false;
            }
        }
    }
}
