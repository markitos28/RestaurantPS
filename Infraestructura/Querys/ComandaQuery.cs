using Aplicacion.Interfaces.Querys;
namespace Infraestructura.Querys
{
    public class ComandaQuery: IComandaQuery
    {
        private readonly RestoDbContext _context;

        public ComandaQuery(RestoDbContext context)
        {
            _context = context;
        }

        
    }
}
