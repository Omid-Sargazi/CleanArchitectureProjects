using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);
            builder.HasIndex(u=>u.Email);
            builder.Property(u=>u.UserName).HasMaxLength(100).IsRequired();
            builder.Property(u=>u.Email).HasMaxLength(250).IsRequired();

            builder.HasMany(u=>u.UserRoles)
            .WithOne(u=>u.User)
            .HasForeignKey(ur=>ur.UserId);
        }
    }
}