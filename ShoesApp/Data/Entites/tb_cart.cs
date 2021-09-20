namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_cart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_cart()
        {
            tb_cartdetails = new HashSet<tb_cartdetails>();
        }

        [Key]
        public int cart_id { get; set; }

        public decimal total_bill { get; set; }

        public int? customer_id { get; set; }

        public int? store_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_cartdetails> tb_cartdetails { get; set; }
    }
}
