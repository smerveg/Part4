using BookStoreWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;


namespace BookStoreWebAPI.Persistence.Context
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseBook> PurchaseBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseBook>().ToTable("PurchaseBook");
            modelBuilder.Entity<Purchase>()
                       .HasMany(o => o.Books)
                       .WithMany(of => of.Purchases)
                       .UsingEntity<PurchaseBook>
                           (oo => oo.HasOne<Book>().WithMany().HasForeignKey(e => e.BookID),
                           oo => oo.HasOne<Purchase>().WithMany().HasForeignKey(e => e.PurchaseID))
                       .Property(oo => oo.Quantity)
                       .IsRequired();

        }
    }
}
