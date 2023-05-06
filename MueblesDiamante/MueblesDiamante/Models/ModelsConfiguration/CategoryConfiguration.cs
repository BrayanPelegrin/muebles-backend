using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MueblesDiamante.Models.Entities;

namespace MueblesDiamante.Models.ModelsConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.HasOne(x => x.Status).WithMany(x => x.Categories).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction);

            var FurnitureCategory = new Category
            {
                Id = 1,
                Name = "Muebles",
                StatusId = 1,
                CreationDate = DateTime.Now,
                UserCreator = "DefaultUser"
            };

            builder.HasData(FurnitureCategory);
        }
    }
}
