using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
             var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
             optionsBuilder.UseSqlServer("Server=.;Database=LibraryDBTwo;User Id=sa;Password=15935755Omid$@;Encrypt=False;");
             return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}