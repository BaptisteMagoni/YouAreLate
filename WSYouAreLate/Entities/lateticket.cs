namespace WSYouAreLate.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.LateTicket")]
    public partial class LateTicket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LateTicket()
        {
            Commentary = new HashSet<Commentary>();
            UserVote = new HashSet<UserVote>();
        }

        public int id { get; set; }

        public DateTime datetime { get; set; }

        public int idUser { get; set; }

        [StringLength(45)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentary> Commentary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserVote> UserVote { get; set; }

        public virtual Users Users { get; set; }
    }
}
