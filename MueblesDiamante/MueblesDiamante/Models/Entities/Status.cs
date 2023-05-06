namespace MueblesDiamante.Models.Entities
{
    public class Status:EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
