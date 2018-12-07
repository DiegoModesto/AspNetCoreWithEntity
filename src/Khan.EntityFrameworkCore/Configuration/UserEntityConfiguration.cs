using Khan.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Khan.EntityFrameworkCore.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(c => c.UserId);

            builder.Property(c => c.FirstName).HasColumnType("varchar(150)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName).HasColumnType("varchar(150)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Password).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Active).IsRequired();

            builder.Property(c => c.CreatedDate).HasColumnType("datetime2").IsRequired();
            builder.Property(c => c.Deleted).IsRequired();
        }
    }
}
