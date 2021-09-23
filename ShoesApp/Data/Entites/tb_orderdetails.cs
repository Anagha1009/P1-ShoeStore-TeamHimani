namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_orderdetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int order_id { get; set; }

        public int? product_id { get; set; }

        public virtual tb_order tb_order { get; set; }

        public virtual tb_products tb_products { get; set; }
    }
}
