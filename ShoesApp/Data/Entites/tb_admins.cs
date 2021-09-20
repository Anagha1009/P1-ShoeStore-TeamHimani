namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_admins
    {
        [Key]
        public int admin_id { get; set; }

        public int? user_id { get; set; }

        [Required]
        [StringLength(20)]
        public string admin_name { get; set; }

        public virtual tb_users tb_users { get; set; }
    }
}
