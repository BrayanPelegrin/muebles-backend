namespace MueblesDiamante.Models.DTO
{
    public class EntityBaseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string? UserCreator { get; set; }
        public string? UserModifier { get; set; }

        public int StatusId { get; set; } = 1;
    }
}
