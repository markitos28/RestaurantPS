using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WAPIRestaurantPS.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class MercaderiaController : ControllerBase
    {
        readonly IMercaderiaServices _services;

        public MercaderiaController(IMercaderiaServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetMercaderia(int? tipo , string? nombre, string orden= "ASC")
        {
            try
            {
                if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC")
                {
                    return new JsonResult(new { Message = "Se ha ingresado el parametro 'orden' incorrectamente. Debe ser ASC o DESC." }) { StatusCode = 400 };
                }
                if (tipo == null && nombre == null)
                {
                    var responseAll = await _services.GetMercaderias();
                    return new JsonResult(responseAll.OrderBy(o => o.Precio));
                }
                
                List<MercaderiaResponse> mercaderias = new List<MercaderiaResponse>();

                if (tipo == null)
                {
                    mercaderias = await _services.GetListMercaderia(-1, nombre, orden.ToUpper());
                }
                else if (string.IsNullOrEmpty(nombre))
                {
                    mercaderias = await _services.GetListMercaderia(tipo.Value , "", orden.ToUpper());
                }
                else
                {
                    mercaderias = await _services.GetListMercaderia(tipo.Value, nombre, orden.ToUpper());
                }

                return new JsonResult(mercaderias);
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el microservicio." }) { StatusCode = 500 };
            }
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMercaderia(int id)
        {
            try
            {
                if (id <= 0)
                {
                    new JsonResult(new { message = "El id ingresado no es valido. Ingrese un valor positivo y distinto de cero." }) { StatusCode = 400 };
                }

                var obj = await  _services.GetMercaderia(id);
                if (obj == null)
                {
                    return new JsonResult(new {message= "La mercaderia que intenta eliminar no existe."}) { StatusCode= 404};
                }
                var delete = await  _services.DeleteMercaderia(id);

                if(delete.response == null)
                {
                    return new JsonResult(new {message = delete.status}) { StatusCode = 409 };
                }

                return new JsonResult(delete.response) { StatusCode = 200 };
                
            }
            catch
            {
                return new JsonResult(new { Message = "Hubo un error en el microservicio. Intente mas tarde" }) { StatusCode = 500 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMercaderia(int id, MercaderiaRequest mercaderia)
        {
            try
            {
                if (id <= 0)
                {
                    new JsonResult(new { message = "El id ingresado no es valido. Ingrese un valor positivo y distinto de cero." }) { StatusCode = 400 };
                }

                var actionChange = await _services.UpdateMercaderia(id,mercaderia);
                if(actionChange.response == null)
                {
                    return new JsonResult(new { message = actionChange.description }) { StatusCode= actionChange.error};
                }
                return new JsonResult(actionChange.response) { StatusCode = 200 };
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el Servidor." }) { StatusCode = 500 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertMercaderia(MercaderiaRequest mercaderia)
        {
            try
            {
                if (mercaderia.Nombre.Length > 50 || mercaderia.Nombre.IsNullOrEmpty() )
                    return new JsonResult(new {Message = "El campo Nombre tiene mas de 50 caracteres, es vacio o no se ha modificado en la estructura."}) { StatusCode = 400};
                if (mercaderia.Tipo <= 0 )
                    return new JsonResult(new { Message = "El campo TipoMercaderiaId debe ser mayor a cero." }) { StatusCode = 400 };
                if (mercaderia.Precio <= 0)
                    return new JsonResult(new { Message = "El campo Precio debe ser mayor a cero." }) { StatusCode = 400 };
                if (mercaderia.Ingredientes.Length > 256 || mercaderia.Ingredientes.IsNullOrEmpty())
                    return new JsonResult(new { Message = "El campo Ingredientes tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura." }) { StatusCode = 400 };
                if (mercaderia.Preparacion.Length > 256 || mercaderia.Preparacion.IsNullOrEmpty())
                    return new JsonResult(new { Message = "El campo Preparacion tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura." }) { StatusCode = 400 };
                if (mercaderia.Imagen.Length > 256 || mercaderia.Imagen.IsNullOrEmpty())
                    return new JsonResult(new { Message = "El campo Imagen tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura." }) { StatusCode = 400 };
                
                if(_services.GetMercaderia(mercaderia.Nombre).Result != null)
                {
                    return new JsonResult(new { Message = "El nombre de la mercaderia que intenta insertar ya existe." }) { StatusCode = 409 };
                }

                var insert= await _services.AddMercaderia(mercaderia);

                if (insert.response == null)
                {
                    return new JsonResult(new { message = insert.error }) { StatusCode = 400 };
                }

                return new JsonResult( insert.response ) { StatusCode = 201 };
                
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servidor. Intente mas tarde" }) { StatusCode = 500 };
            }
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> GetMercaderia(int id)
        {
            try
            {
                if(id <= 0)
                {
                    new JsonResult(new {message= "El id ingresado no es valido. Ingrese un valor positivo y distinto de cero."}) { StatusCode = 400 };
                }
                var selectMercaderia =  await _services.GetMercaderia(id);
                
                if(selectMercaderia != null)
                {
                    return new JsonResult(selectMercaderia);
                }
                else
                {
                    return new JsonResult(new { Message = "La mercaderia que se intenta consultar no existe." }) { StatusCode= 404};
                }
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}
