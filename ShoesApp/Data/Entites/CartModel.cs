using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entites
{
    public partial class CartModel : DbContext
    {
        public CartModel()
            : base("name=CartModel")
        {
        }

        public virtual DbSet<tb_cart> tb_cart { get; set; }
        public virtual DbSet<tb_cartdetails> tb_cartdetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
