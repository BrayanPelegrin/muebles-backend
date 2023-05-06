using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MueblesDiamante.Models.Entities;

namespace MueblesDiamante.Models.ModelsConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price).HasPrecision(10,2);

            builder.Property(x => x.Name);

            builder.Property(x => x.Description);

            builder.Property(x => x.Image);

            builder.Property(x => x.Color);

            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(x => x.Status).WithMany(x => x.Products).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.NoAction); ;

            var mueble = new Product
            {
                Id = 1,
                Price = 4999.99m,
                Name = "Divan De Ceda",
                Color = "Naranja",
                Description = "Divan elegante de color naranja grande",
                Image = "NO DISPONIBLE",
                CategoryId = 1,
                StatusId = 1,
                CreationDate = DateTime.Now,
                UserCreator = "DefaultUser"

            };

            builder.HasData(mueble);

        }
    }
}
