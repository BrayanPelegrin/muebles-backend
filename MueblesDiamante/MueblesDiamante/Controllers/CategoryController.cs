using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MueblesDiamante.Models.Entities;
using MueblesDiamante.Models;
using Microsoft.EntityFrameworkCore;

namespace MueblesDiamante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMuebles()
        {
            var CategoryList = _context.Categories.Include(x => x.Products).AsNoTracking().ToList();

            return CategoryList == Enumerable.Empty<Category>() ? NoContent() : Ok(CategoryList);

        }

        [HttpGet("{id}")]
        public IActionResult GetMueble(int id)
        {
            var CategoryFinded = _context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            return CategoryFinded == null ? NotFound(new { Message = "No existe registro con ese Id" }) : Ok(CategoryFinded);
        }

        [HttpPost]
        public IActionResult SaveMueble(Category model)
        {
            try
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return Ok(model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Ocurrio un Error al Guardar la entidad", Exception = ex.Message });
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMueble([FromRoute] int id, [FromBody] Category mueble)
        {
            var CategoriaBuscado = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (CategoriaBuscado == null)
                 return NotFound(new { Message = "No existe registro con ese Id" });
            
            CategoriaBuscado.Name = mueble.Name;
            _context.Categories.Update(CategoriaBuscado);
            _context.SaveChanges();

            return Ok(CategoriaBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMueble(int id)
        {
            var MuebleBuscado = _context.Products.Include(x => x.Category).Include(x => x.Status).FirstOrDefault(x => x.Id == id);

            var Estado = MuebleBuscado.StatusId;

            MuebleBuscado.StatusId = Estado == 1 ? 2 : 1;

            _context.Products.Update(MuebleBuscado);
            _context.SaveChanges();

            return MuebleBuscado == null ? NotFound(new { Message = "No existe registro con ese Id" }) : Ok(new { Message = Estado == 1 ? "Activo" : "Desactivado" });
        }
    }
}
