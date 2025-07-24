using CarStoreAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarStoreAPI.Data.Mappings
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Description)
                .IsRequired();

            builder.Property(c => c.Stock)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnType("datetime");

            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
