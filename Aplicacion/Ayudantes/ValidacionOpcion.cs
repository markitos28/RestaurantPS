namespace Aplicacion.Ayudantes
{
    public class Validador
    {
        readonly string _validacion;
        public Validador(string opcion)
        {
            _validacion = opcion;
        }

        public (bool esValido , int valor) OpcionValida()
        {
            try
            {
                int valor;
                bool esNumero = int.TryParse(_validacion, out valor);
                return (esNumero, valor);
            }
            catch(Exception ex)
            {
                return (false, -1);
            }
            
        }
    }
}
