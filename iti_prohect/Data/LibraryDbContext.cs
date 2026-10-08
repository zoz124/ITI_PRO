using iti_prohect.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Unique Indexes ─────────────────────────────────────
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.Email)
                .IsUnique();

            // ── Relationships ──────────────────────────────────────

            // Author 1 → * Books
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category 1 → * Books
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Book 1 → * BorrowRecords
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BorrowRecords)
                .WithOne(br => br.Book)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Member 1 → * BorrowRecords
            modelBuilder.Entity<Member>()
                .HasMany(m => m.BorrowRecords)
                .WithOne(br => br.Member)
                .HasForeignKey(br => br.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            // ── Ignore computed property ───────────────────────────
            modelBuilder.Entity<BorrowRecord>()
                .Ignore(br => br.IsReturned);

            // ── Seed Data ──────────────────────────────────────────

            // Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Ahmed Khaled", Bio = "Egyptian novelist and bestselling author." },
                new Author { Id = 2, Name = "Naguib Mahfouz", Bio = "Nobel Prize-winning Egyptian novelist." },
                new Author { Id = 3, Name = "Taha Hussein", Bio = "Pioneer of modern Arabic literature." }
            );

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Science" },
                new Category { Id = 3, Name = "History" }
            );

            // Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Yacoubian Building", ISBN = "978-0-06-087842-5", AuthorId = 1, CategoryId = 1 },
                new Book { Id = 2, Title = "Palace Walk", ISBN = "978-0-385-26466-6", AuthorId = 2, CategoryId = 1 },
                new Book { Id = 3, Title = "The Days", ISBN = "978-977-416-085-6", AuthorId = 3, CategoryId = 3 }
            );
        }
    }
}
