namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_products
    {
        [Key]
        public int product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        public int? category_id { get; set; }

        public int? store_id { get; set; }

        public decimal product_price { get; set; }

        public int product_quantity { get; set; }

        [Required]
        [StringLength(100)]
        public string product_image { get; set; }

        public bool type { get; set; }

        public virtual tb_category tb_category { get; set; }

        public virtual tb_store tb_store { get; set; }

        
    }
}
