using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WAPIRestaurantPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServices _services;

        public ComandaController(IComandaServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Comanda(string? fecha)
        {
            try
            {
                if (fecha == null)
                {
                    // Listar todas las comandas
                }

                DateTime fechaValida;
                var validate = DateTime.TryParse(fecha, out fechaValida);
                if (!validate)
                {
                    return new JsonResult(new { Message = "La fecha ingresada no tiene el formato correcto. Asegurece que el formato sea DD/MM/AAAA" }) { StatusCode = 400 };
                }
                
                var comandas = await _services.GetComandasDetalle(fechaValida);

                if (comandas == null || comandas.Count.Equals(0))
                {
                    return new JsonResult(new { Message = "No existen comandas con esa fecha." }) { StatusCode = 404 };
                }

                return new JsonResult( comandas);
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servicio." }) { StatusCode = 500 };
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> TomarComanda(List<int> mercaderiasIds, int formaEntrega)
        {
            try
            {
                if(mercaderiasIds == null || mercaderiasIds.Count == 0)
                {
                    return new JsonResult(new { Message = "No se ha ingresado mercaderia para realizar la comanda." }) { StatusCode = 400 };
                }
                if(formaEntrega == null)
                {
                    return new JsonResult(new { Message = "No se ha ingresado una forma de entrega para realizar la comanda." }) { StatusCode = 400 };
                }
                return new JsonResult(Ok());
                //_services.InsertComanda(mercaderiasIds, formaEntrega);
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servicio." }) { StatusCode = 500 };
            }
        }
    }
}
