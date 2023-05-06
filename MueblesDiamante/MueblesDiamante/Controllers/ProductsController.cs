﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MueblesDiamante.Models;
using MueblesDiamante.Models.Entities;

namespace MueblesDiamante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ApplicationContext _context;
        public ProductsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMuebles()
        {
            var FurnitureList = _context.Products.Include(x => x.Category).AsNoTracking().ToList();

            return FurnitureList == Enumerable.Empty<Product>() ? NoContent() : Ok(FurnitureList);             
            
        }

        [HttpGet("{id}")]
        public IActionResult GetMueble(int id)
        {
            var MuebleBuscado = _context.Products.Include(x => x.Category).Include(x => x.Status).FirstOrDefault(x => x.Id == id);

            return MuebleBuscado == null ? NotFound(new { Message = "No existe registro con ese Id" }) : Ok(MuebleBuscado);  
        }

        [HttpPost]
        public IActionResult SaveMueble(Product model)
        {
            try
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return Ok(model);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Ocurrio un Error al Guardar la entidad", Exception = ex.Message });
            }
            
        }
                
        [HttpPut("{id}")]
        public IActionResult UpdateMueble([FromRoute]int id, [FromBody]Product mueble)
        {
            var MuebleBuscado = _context.Products.FirstOrDefault(x => x.Id == id);
            if (MuebleBuscado == null)
            {
                return NotFound(new { Message = "No existe registro con ese Id" });
            }


            MuebleBuscado.Name = mueble.Name;
            MuebleBuscado.Description = mueble.Description;
            MuebleBuscado.Color = mueble.Color;
            MuebleBuscado.Image = mueble.Image;
            MuebleBuscado.Price = mueble.Price;

             _context.Products.Update(MuebleBuscado);
            _context.SaveChanges();

            return Ok(MuebleBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMueble(int id)
        {
            var MuebleBuscado = _context.Products.Include(x => x.Category).Include(x => x.Status).FirstOrDefault(x => x.Id == id);

            var Estado = MuebleBuscado.StatusId;

            MuebleBuscado.StatusId = Estado == 1 ? 2 : 1;

            _context.Products.Update(MuebleBuscado);
            _context.SaveChanges();

            return MuebleBuscado == null ? NotFound(new { Message = "No existe registro con ese Id" }) : Ok(new {Message = Estado == 1 ? "Activo" : "Desactivado"});
        }

    }
}
