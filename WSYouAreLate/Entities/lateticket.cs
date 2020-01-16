namespace WSYouAreLate.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.lateticket")]
    public partial class lateticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lateticket()
        {
            users_late = new HashSet<users_late>();
        }

        public int id { get; set; }

        public DateTime datetime { get; set; }

        public int idUser { get; set; }

        [StringLength(45)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users_late> users_late { get; set; }

        public virtual users users { get; set; }
    }
}
