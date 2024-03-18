using Azure;
using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OperationEntity>().Ignore("Id");
            modelBuilder.Entity<OperationEntity>().HasKey("StudentId","BookId");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AuthorEntity> Authors => Set<AuthorEntity>();
        public DbSet<BookEntity> Books => Set<BookEntity>();
        public DbSet<BookTypeEntity> BookTypes => Set<BookTypeEntity>();
        public DbSet<OperationEntity> Operations => Set<OperationEntity>();
        public DbSet<StudentEntity> Students => Set<StudentEntity>();
    }
}
