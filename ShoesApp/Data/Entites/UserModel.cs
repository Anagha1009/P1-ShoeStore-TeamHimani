using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entites
{
    public partial class UserModel : DbContext
    {
        public UserModel()
            : base("name=UserModel")
        {
        }

        public virtual DbSet<tb_admins> tb_admins { get; set; }
        public virtual DbSet<tb_customers> tb_customers { get; set; }
        public virtual DbSet<tb_users> tb_users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_admins>()
                .Property(e => e.admin_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_customers>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_customers>()
                .Property(e => e.customer_contact)
                .IsUnicode(false);

            modelBuilder.Entity<tb_customers>()
                .Property(e => e.customer_email)
                .IsUnicode(false);

            modelBuilder.Entity<tb_users>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<tb_users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tb_users>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
