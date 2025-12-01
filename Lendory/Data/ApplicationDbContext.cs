using Lendory.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lendory.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    
      public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<ProductRequest> ProductRequests { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<NfcTag> NfcTags { get; set; }
        public DbSet<NfcScan> NfcScans { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Beziehungen konfigurieren
            ConfigureItem(builder);
            ConfigureCategory(builder);
            ConfigureBorrow(builder);
            ConfigureFavourite(builder);
            ConfigureProductRequest(builder);
            ConfigureNfc(builder);

        }

        private void ConfigureItem(ModelBuilder builder)
        {
            builder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany()
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureCategory(ModelBuilder builder)
        {
            builder.Entity<ItemCategory>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }

        private void ConfigureBorrow(ModelBuilder builder)
        {
            builder.Entity<Borrow>()
                .HasOne(b => b.User)
                .WithMany() // kein Navigation Property bei IdentityUser
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Borrow>()
                .HasOne(b => b.Item)
                .WithMany()
                .HasForeignKey(b => b.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureFavourite(ModelBuilder builder)
        {
            builder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Favourite>()
                .HasOne(f => f.Item)
                .WithMany()
                .HasForeignKey(f => f.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureProductRequest(ModelBuilder builder)
        {
            builder.Entity<ProductRequest>()
                .HasOne(pr => pr.User)
                .WithMany()
                .HasForeignKey(pr => pr.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
        private void ConfigureNfc(ModelBuilder builder)
        {
            // NFC_TAG → ITEM (1:n)
            builder.Entity<NfcTag>()
                .HasOne(t => t.Item)
                .WithMany()
                .HasForeignKey(t => t.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            // NFC_SCAN → NFC_TAG (1:n)
            builder.Entity<NfcScan>()
                .HasOne(s => s.Tag)
                .WithMany(t => t.Scans)
                .HasForeignKey(s => s.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // NFC_SCAN → USER (optional 1:n)
            builder.Entity<NfcScan>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

}



