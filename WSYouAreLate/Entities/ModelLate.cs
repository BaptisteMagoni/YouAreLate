namespace WSYouAreLate.Entities
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

        public virtual DbSet<lateticket> lateticket { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<users_late> users_late { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<lateticket>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<lateticket>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<lateticket>()
                .HasMany(e => e.users_late)
                .WithRequired(e => e.lateticket)
                .HasForeignKey(e => e.Idlate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.lastname)
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
                .HasMany(e => e.lateticket)
                .WithRequired(e => e.users)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.users_late)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
