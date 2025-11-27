using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l=>l.Id);
            builder.Property(l=>l.Status).HasMaxLength(20).IsRequired();


            builder.Property(l => l.LoanDate)
               .HasColumnType("datetime2")
               .IsRequired();

            builder.Property(l => l.DueDate)
               .HasColumnType("datetime2")
               .IsRequired();

            builder.Property(l => l.ReturnDate)
               .HasColumnType("datetime2");

            builder.HasOne(l=>l.Member)
            .WithMany(m=>m.Loans)
            .HasForeignKey(l=>l.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l=>l.Book)
            .WithMany(b=>b.Loans)
            .HasForeignKey(l=>l.BookId)
            .OnDelete(DeleteBehavior.Restrict);

             builder.HasMany(l => l.Penalties)
               .WithOne(p => p.Loan)
               .HasForeignKey(p => p.LoanId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}