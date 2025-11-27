using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Configurations
{
    public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
    {
        public void Configure(EntityTypeBuilder<Penalty> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Amount).HasColumnType("decimal(10,2)");

            builder.HasOne(p=>p.Member)
            .WithMany(m=>m.Penalties)
            .HasForeignKey(p=>p.MemberId);

            builder.HasOne(p=>p.Loan)
            .WithMany(l=>l.Penalties)
            .HasForeignKey(p=>p.LoanId);
        }
    }
}