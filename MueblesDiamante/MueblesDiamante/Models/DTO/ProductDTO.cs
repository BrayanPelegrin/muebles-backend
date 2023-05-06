namespace MueblesDiamante.Models.DTO
{
    public class ProductDTO:EntityBaseDTO
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public int CategoryId { get; set; }
        public virtual StatusDTO Status { get; set; }

        public virtual CategoryDTO Category { get; set; }
    }

    public class ProductCreacionDTO : EntityBaseDTO
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public int CategoryId { get; set; }
 
    }
}
