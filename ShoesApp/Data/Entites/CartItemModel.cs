using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entites
{
    public partial class CartItemModel : DbContext
    {
        public CartItemModel()
            : base("name=CartItemModel")
        {
        }

        public virtual DbSet<tb_cartitem> tb_cartitem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_cartitem>()
                .Property(e => e.color)
                .IsUnicode(false);
        }
    }
}
