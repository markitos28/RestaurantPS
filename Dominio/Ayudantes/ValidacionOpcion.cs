using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Ayudantes
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
            int valor;
            bool esNumero = int.TryParse(_validacion, out valor);
            return (esNumero, valor);
        }
    }
}
