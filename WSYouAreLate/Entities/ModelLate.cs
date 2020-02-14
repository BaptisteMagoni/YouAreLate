namespace WSYouAreLate.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WSYouAreLate.Configuration;

    public partial class ModelLate : DbContext
    {
        public ModelLate()
            : base(ConnectionStringConfig.LoadConnectionString())
        {
        }

        public virtual DbSet<LateTicket> LateTicket { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersLate> UsersLate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LateTicket>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<LateTicket>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<LateTicket>()
                .HasMany(e => e.UsersLate)
                .WithRequired(e => e.LateTicket)
                .HasForeignKey(e => e.idlate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.identifiant)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.classe)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.LateTicket)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersLate)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.iduser)
                .WillCascadeOnDelete(false);
        }
    }
}
