namespace MueblesDiamante.Models.DTO
{
    public class CategoryDTO : EntityBaseDTO
    {
        public string? Name { get; set; }
        public virtual StatusDTO Status { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
    public class CategoryCreacionDTO : EntityBaseDTO
    {
        public string? Name { get; set; }

    }
}
