using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MueblesDiamante.Models;

namespace MueblesDiamante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        public List<Furniture> muebles = new List<Furniture>()
        {
            new Furniture { Id = 1, Color = "Rojo", Descripcion = "Mueble Rojo de tela fina",
            Image = "No Hay", Nombre = "Mueble Elegante", Precio = 4999.99m},

            new Furniture { Id = 2, Color = "Rojo", Descripcion = "Mueble Rojo de tela fina",
            Image = "No Hay", Nombre = "Mueble Elegante", Precio = 4999.99m},

            new Furniture { Id = 3, Color = "Rojo", Descripcion = "Mueble Rojo de tela fina",
            Image = "No Hay", Nombre = "Mueble Elegante", Precio = 4999.99m},

            new Furniture { Id = 4, Color = "Rojo", Descripcion = "Mueble Rojo de tela fina",
            Image = "No Hay", Nombre = "Mueble Elegante", Precio = 4999.99m},
            
        };

        [HttpGet]
        public List<Furniture> GetMuebles()
        {
            
            return muebles;
        }

        [HttpGet("{id}")]
        public Furniture GetMueble(int id)
        {
            var MuebeBuscado = muebles.Find(x => x.Id == id);
            return MuebeBuscado;
        } 

    }
}
