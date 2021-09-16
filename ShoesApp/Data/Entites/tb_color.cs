namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_color
    {
        [Key]
        public int color_id { get; set; }

        [Required]
        [StringLength(10)]
        public string color { get; set; }

        public virtual tb_productcolor tb_productcolor { get; set; }
    }
}
