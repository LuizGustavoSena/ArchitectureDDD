using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("City");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Cod);
            builder.HasOne(u => u.State)
                    .WithMany(c => c.Cities);
        }
    }
}