using System.Dynamic;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> optiosn):base(optiosn){}

        public DbSet<User> Users =>Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<Penalty> Penalties => Set<Penalty>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}