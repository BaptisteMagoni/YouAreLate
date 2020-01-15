namespace WSYouAreLate.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdd_late.retard")]
    public partial class retard
    {
        [Key]
        public int idretard { get; set; }

        public DateTime datetime { get; set; }

        public int idUser { get; set; }

        [StringLength(45)]
        public string Matiere { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int? vote { get; set; }

        public virtual users users { get; set; }
    }
}
