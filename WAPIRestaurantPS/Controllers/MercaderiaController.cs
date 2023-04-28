using Aplicacion.Interfaces.Servicios;
using Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;


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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMercaderia(int id)
        {
            try
            {
                var obj =  _services.GetMercaderia(id);
                if (obj == null)
                {
                    return NotFound(new {Message= "La mercaderia que intenta eliminar no existe."});
                }
                var delete = await  _services.DeleteMercaderia(id);

                if (delete == true)
                {
                    return new JsonResult(obj) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(new { Message = "No se pudo eliminar la mercaderia" }) { StatusCode = 400 };
                }
            }
            catch
            {
                return new JsonResult(new { Message = "Hubo un error en el servidor. Intente mas tarde" }) { StatusCode = 409 };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMercaderia(int id, MercaderiaRequest mercaderia)
        {
            try
            {
                var bbddMercaderia =  _services.GetMercaderia(id).Result;
                if(bbddMercaderia == null)
                {
                    return new JsonResult(new {Message = "El ID de mercaderia ingresado no existe para ser modificado."}) { StatusCode = 404 };
                }
                
                MercaderiaDTO changeMercaderia = new MercaderiaDTO()
                {
                    MercaderiaId = id,
                    Nombre = mercaderia.Nombre == "" || mercaderia.Nombre == "string" ? bbddMercaderia.Nombre : mercaderia.Nombre,
                    TipoMercaderiaId = mercaderia.TipoMercaderiaId == 0 ? bbddMercaderia.TipoMercaderiaId: mercaderia.TipoMercaderiaId,
                    Precio = mercaderia.Precio == 0 ? bbddMercaderia.Precio : mercaderia.Precio,
                    Ingredientes = mercaderia.Ingredientes == "" || mercaderia.Ingredientes == "string" ? bbddMercaderia.Ingredientes: mercaderia.Ingredientes,
                    Preparacion = mercaderia.Preparacion == "" || mercaderia.Preparacion  == "string" ? bbddMercaderia.Preparacion : mercaderia.Preparacion,
                    Imagen = mercaderia.Imagen == "" || mercaderia.Imagen == "string" ? bbddMercaderia.Imagen : mercaderia.Imagen
                };

                var actionChange = await _services.UpdateMercaderia(changeMercaderia);
                if(actionChange != null)
                {
                    return new JsonResult(actionChange) { StatusCode= 200};
                }
                else
                {
                    return new JsonResult(new {Message= "Ha ingresado datos incorrectos en los parametros."}) { StatusCode = 400 };
                }
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el Servidor." }) { StatusCode = 409 };
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertMercaderia(MercaderiaRequest mercaderia)
        {
            try
            {
                if (mercaderia.Nombre.Length > 50 || mercaderia.Nombre == "" || mercaderia.Nombre == "string")
                    return new JsonResult(new {Message = "El campo Nombre tiene mas de 50 caracteres, es vacio o no se ha modificado en la estructura del JSON."}) { StatusCode = 400};
                if (mercaderia.TipoMercaderiaId == 0 )
                    return new JsonResult(new { Message = "El campo TipoMercaderiaId no se ha modificado en la estructura del JSON." }) { StatusCode = 400 };
                if (mercaderia.Precio == 0)
                    return new JsonResult(new { Message = "El campo Precio no se ha modificado en la estructura del JSON." }) { StatusCode = 400 };
                if (mercaderia.Ingredientes.Length > 256 || mercaderia.Ingredientes == "" || mercaderia.Ingredientes == "string")
                    return new JsonResult(new { Message = "El campo Ingredientes tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura del JSON." }) { StatusCode = 400 };
                if (mercaderia.Preparacion.Length > 256 || mercaderia.Preparacion == "" || mercaderia.Preparacion == "string")
                    return new JsonResult(new { Message = "El campo Preparacion tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura del JSON." }) { StatusCode = 400 };
                if (mercaderia.Imagen.Length > 256 || mercaderia.Imagen == "" || mercaderia.Imagen == "string")
                    return new JsonResult(new { Message = "El campo Imagen tiene mas de 255 caracteres, es vacio o no se ha modificado en la estructura del JSON." }) { StatusCode = 400 };


                MercaderiaDTO mapMercaderia = new MercaderiaDTO()
                {
                    Nombre = mercaderia.Nombre,
                    TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                    Precio = mercaderia.Precio,
                    Ingredientes= mercaderia.Ingredientes,
                    Preparacion = mercaderia.Preparacion,
                    Imagen = mercaderia.Imagen
                };

                var insert= await _services.AddMercaderia(mapMercaderia);

                if(insert != null)
                {
                    return new JsonResult(insert) { StatusCode = 201 };
                }

                else
                {
                    return new JsonResult(new { Message = "No se ha insertado la mercaderia debido a un error." }) { StatusCode = 409 };
                }
                
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
                var selectMercaderia =  await _services.GetMercaderia(id);
                
                if(selectMercaderia != null)
                {
                    return new JsonResult(selectMercaderia);
                }
                else
                {
                    return NotFound(new { Message = "La mercaderia que se intenta consultar no existe." });
                }
            }
            catch
            {
                return new JsonResult(new { Message = "Ha ocurrido un error en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}
