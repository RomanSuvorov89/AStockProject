namespace Diplom.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SQLdb : DbContext
    {
        public SQLdb()
            : base("name=SQLdb")
        {
        }

        public virtual DbSet<AudioCards> AudioCards { get; set; }
        public virtual DbSet<Boxes> Boxes { get; set; }
        public virtual DbSet<Cpus> Cpus { get; set; }
        public virtual DbSet<FormFactorMB> FormFactorMB { get; set; }
        public virtual DbSet<HDDs> HDDs { get; set; }
        public virtual DbSet<HDDType> HDDType { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<MotherBoards> MotherBoards { get; set; }
        public virtual DbSet<partsFreq> partsFreq { get; set; }
        public virtual DbSet<Powers> Powers { get; set; }
        public virtual DbSet<Rams> Rams { get; set; }
        public virtual DbSet<RamType> RamType { get; set; }
        public virtual DbSet<slotBus> slotBus { get; set; }
        public virtual DbSet<Sockets> Sockets { get; set; }
        public virtual DbSet<VideoCards> VideoCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioCards>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Boxes>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cpus>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HDDs>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MotherBoards>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Powers>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Rams>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VideoCards>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
