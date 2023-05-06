namespace MueblesDiamante.Models.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string? UserCreator { get; set; }
        public string? UserModifier { get; set; }

        public int StatusId { get; set; }
    }
}
