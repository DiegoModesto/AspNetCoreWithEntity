using Khan.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khan.EntityFrameworkCore.Configuration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(c => c.RoleId);

            builder.Property(c => c.Name).HasColumnType("varchar(150)").HasMaxLength(150).IsRequired();
            builder.Property(c => c.Level).HasColumnType("int").IsRequired();

            builder.Property(c => c.CreatedDate).HasColumnType("datetime2").IsRequired();
            builder.Property(c => c.Deleted).IsRequired();
        }
    }
}
