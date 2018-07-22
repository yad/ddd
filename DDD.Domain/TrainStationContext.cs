using DDD.Domain.Passenger;
using DDD.Domain.Train;
using Microsoft.EntityFrameworkCore;

namespace DDD.Domain
{
    public class TrainStationContext : DbContext
    {
        public TrainStationContext(DbContextOptions<TrainStationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PassengerEntity> TPassenger { get; set; }
        public virtual DbSet<TrainEntity> TTrain { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("T_Passenger", "sch_station");

                entity.Property(e => e.Id)
                    .HasColumnName("PAS_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("PAS_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrainId).HasColumnName("PAS_TRA_Id").IsRequired();

                entity.HasOne(d => d.Train)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.TrainId)
                    .HasConstraintName("FK_T_Passenger_T_Train");
            });

            modelBuilder.Entity<TrainEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("T_Train", "sch_station");

                entity.Property(e => e.Id)
                    .HasColumnName("TRA_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("TRA_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
