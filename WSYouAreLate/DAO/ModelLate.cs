namespace WSYouAreLate.DAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelLate : DbContext
    {
        public ModelLate()
            : base("name=ModelLate")
        {
        }

        public virtual DbSet<retard> retard { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<retard>()
                .Property(e => e.Matiere)
                .IsUnicode(false);

            modelBuilder.Entity<retard>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.identifiant)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.classe)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.retard)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);
        }
    }
}
