namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_order
    {
        [Key]
        public int order_id { get; set; }

        public int? customer_id { get; set; }

        public int? store_id { get; set; }

        public decimal total_bill { get; set; }

        public DateTime date { get; set; }

        public virtual tb_orderdetails tb_orderdetails { get; set; }
    }
}
