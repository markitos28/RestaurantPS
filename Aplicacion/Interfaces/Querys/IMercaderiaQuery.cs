using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IMercaderiaQuery
    {
        public List<Mercaderia> SelectListaMercaderia();
        public Mercaderia SelectMercaderia(string nombre);
        public List<Mercaderia> SelectLikeMercaderia(string nombre);
        public List<Mercaderia> SelectListaMercaderia(int tipoMercaderia);
        public Mercaderia SelectMercaderia(int mercaderiaId);
    }
}
