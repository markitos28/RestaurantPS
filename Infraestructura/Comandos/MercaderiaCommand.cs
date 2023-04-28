using Aplicacion.Interfaces.Comandos;
using Dominio.DTOs;
using Dominio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SlnManagerText;


namespace Infraestructura.Comandos
{
    public class MercaderiaCommand : IMercaderiaCommand
    {
        readonly private RestoDbContext _context;

        public MercaderiaCommand(RestoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMercaderia(int id)
        {
            try
            {
                var mercaderia = (from m in _context.Mercaderia
                                  where m.MercaderiaId == id
                                  select m).FirstOrDefault();
                if (mercaderia != null)
                {
                    _context.Mercaderia.Remove(mercaderia);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return false;
            }
            catch (SqlException ex)
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

        public async Task<MercaderiaDTO> InsertMercaderia(MercaderiaDTO mercaderia)
        {
            try
            {
                var maxMercaderia = (from m in _context.Mercaderia
                             select m).OrderByDescending(o => o.MercaderiaId).FirstOrDefault();
                Mercaderia mapMercaderia = new Mercaderia()
                {
                    TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                    Nombre = mercaderia.Nombre,
                    Precio = mercaderia.Precio,
                    Ingredientes = mercaderia.Ingredientes,
                    Preparacion = mercaderia.Preparacion,
                    Imagen = mercaderia.Imagen
                };
                var response = _context.Add(mapMercaderia);
                await _context.SaveChangesAsync();
                mercaderia.MercaderiaId= response.Entity.MercaderiaId;
                return mercaderia;
            }
            catch (DbUpdateException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return null;
            }
            catch (SqlException ex)
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

        public Task<MercaderiaDTO> UpdateMercaderia(MercaderiaDTO mercaderia)
        {
            
            try
            {
                var select = (from m in _context.Mercaderia
                              where m.MercaderiaId == mercaderia.MercaderiaId
                              select m).FirstOrDefault();
                if (select != null )
                {
                    select.Nombre = mercaderia.Nombre;
                    select.Precio = mercaderia.Precio;
                    select.Preparacion = mercaderia.Preparacion;
                    select.Ingredientes = mercaderia.Ingredientes;
                    select.Imagen = mercaderia.Imagen;
                    select.TipoMercaderiaId = mercaderia.TipoMercaderiaId;

                    _context.SaveChanges();
                    return Task.FromResult(mercaderia);
                }
                
                return null;
                
                
            }
            catch (DbUpdateException ex)
            {
                var log = new ManagerText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Logs"));
                if (log.createLog())
                {
                    log.writeLog(String.Concat("El proceso arrojo un error en la linea ", ex.Message, " del archivo ", this.GetType()));
                }
                return null;
            }
            catch (SqlException ex)
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
