using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica02.Models;

namespace Practica02.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        Servicios.AdminArticulos Aa = new Servicios.AdminArticulos();
         

        [HttpGet]
        public IActionResult Get()
        {
            List<Articulo> list = Aa.ObtenerList();
            if (list.Count == 0)
            {
                return BadRequest("No hay articulos en la BD");
            }
            return Ok(list);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Articulo articulo = Aa.Obtener(id);
            if (articulo == null)
            {
                return BadRequest("Articulo no encontrado");
            }
            return Ok(articulo);

        }

        [HttpPost]

        public IActionResult Post([FromBody] Models.Articulo a)
        {

            if (a == null || string.IsNullOrEmpty(a.Nombre) || a.Precio <= 0)
            {
                return BadRequest("Datos incorrectos!!");
            }

            Aa.Guardar(a);


            return Ok("Articulo Guardado");

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Models.Articulo a)
        {
            if (!Aa.Borrar(a.Id))
            {
                return BadRequest("No se pudo borrar!");
            }

            return Ok("Articulo Borrado");
        }

    }
}
