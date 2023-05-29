using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WAPIRestaurantPS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServices _services;

        public ComandaController(IComandaServices services)
        {
            _services = services;
        }



        [HttpGet]
        public async Task<IActionResult> Comanda([FromQuery]string? fecha)
        {
            try
            {
                if (fecha == null)
                {
                    var comandasAll= await _services.GetComandasDetalleAll();
                    return new JsonResult(comandasAll);
                }

                DateTime fechaValida;
                var validate = DateTime.TryParse(fecha, out fechaValida);
                if (!validate)
                {
                    return new JsonResult(new { Message = "La fecha ingresada no tiene el formato correcto. Asegurese que el formato sea uno soportado. Ejemplo: DD/MM/AAAA" }) { StatusCode = 400 };
                }

                var comandas = await _services.GetComandasDetalle(fechaValida);

                if (comandas == null || comandas.Count.Equals(0))
                {
                    return new JsonResult(new { }) { StatusCode = 200 };
                }

                return new JsonResult(comandas);
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servicio." }) { StatusCode = 500 };
            }

        }

        [HttpPost]
        public async Task<IActionResult> TomarComanda(PedidoComandaDTO pedido)
        {
            try
            {
                if(pedido == null)
                {
                    return new JsonResult(new { Message = "No se ha ingresado un pedido para realizar la comanda." }) { StatusCode = 400 };
                }
                if (pedido.Mercaderias == null || pedido.Mercaderias.Count == 0 || (pedido.Mercaderias[0].Equals(0) && pedido.FormaEntrega.Equals(0)))
                {
                    return new JsonResult(new { Message = "No se ha ingresado mercaderia para realizar la comanda." }) { StatusCode = 400 };
                }
                if (pedido.FormaEntrega.Equals(0) || pedido.FormaEntrega.ToString().IsNullOrEmpty())
                {
                    return new JsonResult(new { Message = "No se ha ingresado una forma de entrega para realizar la comanda." }) { StatusCode = 400 };
                }
                var insert = await _services.InsertComanda(pedido.Mercaderias, pedido.FormaEntrega);
                
                if(insert.response == null)
                {
                    return new JsonResult(new { Message = insert.error }) { StatusCode = 400 };
                }

                return new JsonResult(insert.response) { StatusCode = 201 };
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servicio." }) { StatusCode = 500 };
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ComandaById(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return new JsonResult(new { Message = "Error: No se ha ingresado un valor de ID de comanda valido para buscar" }) { StatusCode = 400 };
                }
                var comanda = await _services.GetComanda(id);

                if (comanda == null)
                {
                    return new JsonResult(new { message = $"No existe una comanda con el ID : {id}"}) { StatusCode = 404 };
                }

                return new JsonResult(comanda);
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servicio." }) { StatusCode = 500 };
            }

        }
    }
}
