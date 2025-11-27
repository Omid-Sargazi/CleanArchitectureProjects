using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b=>b.Id);
            builder.Property(b=>b.Author).HasMaxLength(150).IsRequired();
            builder.Property(b=>b.Title).HasMaxLength(200).IsRequired();
            builder.HasIndex(b=>b.ISBN).IsUnique();
        }
    }
}