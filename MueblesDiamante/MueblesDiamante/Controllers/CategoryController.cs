using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MueblesDiamante.Models.Entities;
using MueblesDiamante.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MueblesDiamante.Models.DTO;

namespace MueblesDiamante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CategoryController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMuebles()
        {
            var CategoryList = _context.Categories.Include(x => x.Products).AsNoTracking().ToList();

            return CategoryList == Enumerable.Empty<Category>() ? NoContent() : Ok(_mapper.Map<List<Category>>(CategoryList));

        }

        [HttpGet("{id}")]
        public IActionResult GetMueble(int id)
        {
            var CategoryFinded = _context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            return CategoryFinded == null ? NotFound(new { Message = "No existe registro con ese Id" }) : Ok(_mapper.Map<CategoryDTO>(CategoryFinded));
        }

        [HttpPost]
        public IActionResult SaveMueble(CategoryCreacionDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<Category>(modelDTO);
                model.StatusId = 1;
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
        public IActionResult UpdateMueble([FromRoute] int id, [FromBody] CategoryCreacionDTO mueble)
        {
            var CategoriaBuscado = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (CategoriaBuscado == null)
                 return NotFound(new { Message = "No existe registro con ese Id" });
            
            CategoriaBuscado.Name = mueble.Name;
            CategoriaBuscado.StatusId = 1;
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
