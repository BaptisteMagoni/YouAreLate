namespace WSYouAreLate.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.users")]
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            retard = new HashSet<retard>();
        }

        [Key]
        public int idusers { get; set; }

        [StringLength(45)]
        public string Nom { get; set; }

        [StringLength(45)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(45)]
        public string identifiant { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        [StringLength(45)]
        public string classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<retard> retard { get; set; }
    }
}
