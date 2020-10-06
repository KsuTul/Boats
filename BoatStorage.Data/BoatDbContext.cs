namespace Boatstorage.Data
{
    using Boatstorage.Data.DAO;
    using Microsoft.EntityFrameworkCore;
    using System;

    public partial class BoatDbContext : DbContext
    {
        public BoatDbContext(DbContextOptions<BoatDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boat> Boats { get; set; }

        public virtual DbSet<BoatSpecificParameters> BoatsSpecificParameters { get; set; }

        public virtual DbSet<CurrentParamsJournal> CurrentParamsJournal { get; set; }

        public virtual DbSet<CurrentParamsJournalSpecParams> CurrentParamsJournalSpecParams { get; set; }

        public object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<InspectionJournal> InspectionJournal { get; set; }

        public virtual DbSet<InspectionJournalsSpecParams> InspectionJournalsSpecParams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=C:\\USERS\\XENIA\\SOURCE\\WORKSPACES\\LEARNINGPROJECTS\\MAIN\\SOURCE\\XENIA\\BOATSTORAGE\\DATA\\BOATS.MDF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>(entity =>
            {
                entity.Property(e => e.BoatType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(b => b.Id)
                .IsUnique();
            });

            modelBuilder.Entity<BoatSpecificParameters>(entity =>
            {
                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.BoatsSpecificParameters)
                    .HasForeignKey(d => d.BoatId)
                    .HasConstraintName("FK__BoatsSpec__BoatI__7FEAFD3E");
            });

            modelBuilder.Entity<CurrentParamsJournal>(entity =>
            {
                entity.Property(e => e.LastDate).HasColumnType("datetime");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.CurrentParamsJournal)
                    .HasForeignKey(d => d.BoatId)
                    .HasConstraintName("FK__CurrentPa__BoatI__00DF2177");
            });

            modelBuilder.Entity<CurrentParamsJournalSpecParams>(entity =>
            {
                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.CurrentParamsJournal)
                    .WithMany(p => p.CurrentParamsJournalSpecParams)
                    .HasForeignKey(d => d.CurrentParamsJournalId)
                    .HasConstraintName("FK__CurrentPa__Curre__01D345B0");
            });

            modelBuilder.Entity<InspectionJournal>(entity =>
            {
                entity.Property(e => e.LastDate).HasColumnType("datetime");

                entity.HasOne(d => d.Boat)
                    .WithMany(p => p.InspectionJournal)
                    .HasForeignKey(d => d.BoatId)
                    .HasConstraintName("FK__Inspectio__BoatI__02C769E9");
            });

            modelBuilder.Entity<InspectionJournalsSpecParams>(entity =>
            {
                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.TechnicalJournal)
                    .WithMany(p => p.InspectionJournalsSpecParams)
                    .HasForeignKey(d => d.TechnicalJournalId)
                    .HasConstraintName("FK__Inspectio__Techn__03BB8E22");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
