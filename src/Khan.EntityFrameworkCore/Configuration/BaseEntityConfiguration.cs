using Khan.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khan.EntityFrameworkCore.Configuration
{
    public abstract class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(c => c.CreatedDate).HasColumnType("datetime2").IsRequired();
            builder.Property(c => c.Deleted).IsRequired();
        }
    }
}
