namespace WSYouAreLate.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.Commentary")]
    public partial class Commentary
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iduser { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idlate { get; set; }

        [StringLength(255)]
        public string message { get; set; }

        public DateTime date { get; set; }

        public virtual LateTicket LateTicket { get; set; }

        public virtual Users Users { get; set; }
    }
}
