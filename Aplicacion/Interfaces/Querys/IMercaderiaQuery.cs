using Dominio.Entidades;

namespace Aplicacion.Interfaces.Querys
{
    public interface IMercaderiaQuery
    {
        public List<Mercaderia> SelectListaMercaderia(); // Retorna la tabla completa
        public Task<Mercaderia> SelectMercaderia(string nombre); // Retorna la primer mercaderia que encuentre con el nombre exacto de parametro
        public List<Mercaderia> SelectListaMercaderia(int tipoMercaderia); //Retorna una lista de las mercaderias con el tipoId del parametro 
        public Task<Mercaderia> SelectMercaderia(int mercaderiaId); // Retorna uan mercaderia con el ID exacto pasado por parametros
        public List<Mercaderia> SelectLikeMercaderia(string nombre); // Retorna una lista de mercaderias que contengan el nombre de parametros
        public List<Mercaderia> SelectMercaderia(int tipo, string nombre);

    }
}
