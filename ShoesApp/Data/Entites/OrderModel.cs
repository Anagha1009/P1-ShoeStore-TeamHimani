using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entites
{
    public partial class OrderModel : DbContext
    {
        public OrderModel()
            : base("name=OrderModel")
        {
        }

        public virtual DbSet<tb_order> tb_order { get; set; }
        public virtual DbSet<tb_orderdetails> tb_orderdetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_order>()
                .HasOptional(e => e.tb_orderdetails)
                .WithRequired(e => e.tb_order);
        }
    }
}
