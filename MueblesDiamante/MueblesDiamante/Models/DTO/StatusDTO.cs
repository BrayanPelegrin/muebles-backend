namespace MueblesDiamante.Models.DTO
{
    public class StatusDTO:EntityBaseDTO
    {
        public string Name { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
        public virtual ICollection<CategoryDTO> Categories { get; set; }
    }
    public class StatusCreacionDTO : EntityBaseDTO
    {
        public string Name { get; set; }

    }
}
