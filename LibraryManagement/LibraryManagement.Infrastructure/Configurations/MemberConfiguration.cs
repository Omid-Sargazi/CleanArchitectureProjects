using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m=>m.Id);
            builder.Property(m=>m.MemberShipNumber).HasMaxLength(25).IsRequired();
            builder.HasIndex(m=>m.MemberShipNumber).IsUnique();

            builder.HasOne(m=>m.User)
            .WithOne(u=>u.Member)
            .HasForeignKey<Member>(m=>m.UserId);

            builder.HasMany(m=>m.Loans)
            .WithOne(l=>l.Member)
            .HasForeignKey(l=>l.MemberId);

            builder.HasMany(m=>m.Penalties)
            .WithOne(p=>p.Member)
            .HasForeignKey(p=>p.MemberId);
        }
    }
}