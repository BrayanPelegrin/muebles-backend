namespace MueblesDiamante.Models.Entities
{
    public class Product:EntityBase
    {
        
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public int CategoryId { get; set; }
        public virtual Status Status { get; set; }

        public virtual Category Category { get; set; }

    }
}
