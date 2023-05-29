using Aplicacion.Interfaces.Querys;
using Dominio.Entidades;

namespace Infraestructura.Querys
{
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly RestoDbContext _context;

        public TipoMercaderiaQuery(RestoDbContext context)
        {
            _context = context;
        }
        public async Task<TipoMercaderia> GetTipoMercaderia(int id)
        {
            var query = (from tm in _context.TipoMercaderia
                         where tm.TipoMercaderiaId == id
                         select tm).FirstOrDefault();

            return query;
        }
    }
}
