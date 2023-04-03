using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IMercaderiaQuery
    {
        List<Mercaderia> SelectMercaderia();
        Mercaderia SelectMercaderia(string nombre);
        List<Mercaderia> SelectLikeMercaderia(string nombre);
        List<Mercaderia> SelectMercaderia(int tipoMercaderia);
    }
}
