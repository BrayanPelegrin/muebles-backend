namespace MueblesDiamante.Models.Entities
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
