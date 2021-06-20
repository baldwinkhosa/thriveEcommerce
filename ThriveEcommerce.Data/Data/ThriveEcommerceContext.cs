using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThriveEcommerce.Domain.Entities;

namespace ThriveEcommerce.Data.Data
{
    public class ThriveEcommerceContext : IdentityDbContext<IdentityUser>
    {
        public ThriveEcommerceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<ProductWishlist> ProductWishlists { get; set; }
        public DbSet<ProductCompare> ProductCompares { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<ProductRelatedProduct> ProductRelatedProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);

            base.OnModelCreating(builder); 
            builder.Entity<Order>(ConfigureOrder);
    
            builder.Entity<Product>(ConfigureProduct);

            builder.Entity<ProductWishlist>(ConfigureProductWishlist);
            builder.Entity<ProductCompare>(ConfigureProductCompare);
            builder.Entity<ProductList>(ConfigureProductList);
            builder.Entity<ProductRelatedProduct>(ConfigureProductRelatedProduct);
        }

        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            //// NOTE : This Owns methods provide to accept value object like Address
            //builder.OwnsOne(o => o.ShippingAddress);
            //builder.OwnsOne(o => o.BillingAddress);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasMany(p => p.ProductRelatedProducts)
                .WithOne(pr => pr.Product)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureProductWishlist(EntityTypeBuilder<ProductWishlist> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.WishlistId });
        }

        private void ConfigureProductCompare(EntityTypeBuilder<ProductCompare> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.CompareId });
        }

        private void ConfigureProductList(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.ListId });
        }

        private void ConfigureProductRelatedProduct(EntityTypeBuilder<ProductRelatedProduct> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.RelatedProductId });
        }
    }
}
