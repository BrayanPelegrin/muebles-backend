using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MueblesDiamante.Models;

namespace MueblesDiamante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {

        private readonly ApplicationContext _context;
        public FurnitureController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMuebles()
        {
            var FurnitureList = _context.Furnitures.ToList();
            if (FurnitureList == Enumerable.Empty<Furniture>())
                return NoContent();
            else
                return Ok(FurnitureList);
        }

        [HttpPost]
        public IActionResult SaveMueble(Furniture model)
        {
            try
            {
                _context.Furnitures.Add(model);
                _context.SaveChanges();
                return Ok(model);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Ocurrio un Error al Guardar la entidad", Exception = ex.Message });
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetMueble(int id)
        {
            var MuebleBuscado = _context.Furnitures.FirstOrDefault(x => x.Id == id);
            if(MuebleBuscado == null)
                return NotFound(new { Message = "No existe registro con ese Id" });
            else
            return Ok(MuebleBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMueble([FromRoute]int id, [FromBody]Furniture mueble)
        {
            var MuebleBuscado = _context.Furnitures.FirstOrDefault(x => x.Id == id);
            if (MuebleBuscado == null)
            {
                return NotFound(new { Message = "No existe registro con ese Id" });
            }


            MuebleBuscado.Nombre = mueble.Nombre;
            MuebleBuscado.Descripcion = mueble.Descripcion;
            MuebleBuscado.Color = mueble.Color;
            MuebleBuscado.Image = mueble.Image;
            MuebleBuscado.Precio = mueble.Precio;

             _context.Furnitures.Update(MuebleBuscado);
            _context.SaveChanges();

            return Ok(MuebleBuscado);
        }

    }
}
