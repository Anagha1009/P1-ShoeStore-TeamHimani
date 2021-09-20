namespace Data.Entites
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_users()
        {
            tb_admins = new HashSet<tb_admins>();
            tb_customers = new HashSet<tb_customers>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(10)]
        public string username { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }

        [Required]
        [StringLength(10)]
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_admins> tb_admins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_customers> tb_customers { get; set; }
    }
}
