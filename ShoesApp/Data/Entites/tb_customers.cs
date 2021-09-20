namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_customers
    {
        [Key]
        public int customer_id { get; set; }

        public int? user_id { get; set; }

        [Required]
        [StringLength(20)]
        public string customer_name { get; set; }

        [Required]
        [StringLength(10)]
        public string customer_contact { get; set; }

        [Required]
        [StringLength(250)]
        public string customer_email { get; set; }

        public virtual tb_users tb_users { get; set; }
    }
}
