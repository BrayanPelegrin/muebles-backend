using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MueblesDiamante.Models.Entities;

namespace MueblesDiamante.Models.ModelsConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.HasMany(x => x.Categories).WithOne(x => x.Status).OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(x => x.StatusId);

            var active = new Status
            {
                Id = 1,
                Name = "Activo",
                CreationDate = DateTime.Now,
                UserCreator = "DefaultUser"
            };

            var Inactive = new Status
            {
                Id = 2,
                Name = "Inactivo",
                CreationDate = DateTime.Now,
                UserCreator = "DefaultUser"
            };

            builder.HasData(active, Inactive);
        }
    }
}
