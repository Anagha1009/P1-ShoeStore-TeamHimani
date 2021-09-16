using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entites
{
    public partial class ProductModel : DbContext
    {
        public ProductModel()
            : base("name=ProductModel")
        {
        }

        public virtual DbSet<tb_category> tb_category { get; set; }
        public virtual DbSet<tb_color> tb_color { get; set; }
        public virtual DbSet<tb_products> tb_products { get; set; }
        public virtual DbSet<tb_sizes> tb_sizes { get; set; }
        public virtual DbSet<tb_store> tb_store { get; set; }
        public virtual DbSet<tb_productcolor> tb_productcolor { get; set; }
        public virtual DbSet<tb_productsize> tb_productsize { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_color>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<tb_color>()
                .HasOptional(e => e.tb_productcolor)
                .WithRequired(e => e.tb_color);

            modelBuilder.Entity<tb_products>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_products>()
                .Property(e => e.product_image)
                .IsUnicode(false);

            modelBuilder.Entity<tb_sizes>()
                .HasOptional(e => e.tb_productsize)
                .WithRequired(e => e.tb_sizes);

            modelBuilder.Entity<tb_store>()
                .Property(e => e.store_name)
                .IsUnicode(false);
        }
    }
}
