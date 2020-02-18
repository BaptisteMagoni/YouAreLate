namespace WSYouAreLate.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.Users")]
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            LateTicket = new HashSet<LateTicket>();
            Commentary = new HashSet<Commentary>();
            UserVote = new HashSet<UserVote>();
        }

        public int id { get; set; }

        [StringLength(45)]
        public string firstname { get; set; }

        [StringLength(45)]
        public string lastname { get; set; }

        [Required]
        [StringLength(45)]
        public string identifiant { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        [StringLength(45)]
        public string classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LateTicket> LateTicket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commentary> Commentary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserVote> UserVote { get; set; }
    }
}
