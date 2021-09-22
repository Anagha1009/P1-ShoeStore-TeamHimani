namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_cartitem
    {
        [Key]
        public int cart_id { get; set; }

        public int? customer_id { get; set; }

        public int? store_id { get; set; }

        public int? product_id { get; set; }

        [StringLength(10)]
        public string color { get; set; }

        public decimal? size { get; set; }
    }
}
