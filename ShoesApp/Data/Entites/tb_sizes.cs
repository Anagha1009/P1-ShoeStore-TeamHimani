namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_sizes
    {
        [Key]
        public int size_id { get; set; }

        public decimal size { get; set; }

        public virtual tb_productsize tb_productsize { get; set; }
    }
}
