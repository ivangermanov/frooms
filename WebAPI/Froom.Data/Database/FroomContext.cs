using System.Collections.Generic;
using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Froom.Data.Database
{
    public class FroomContext : DbContext
    {
        public FroomContext(DbContextOptions<FroomContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options =>
            {
                options.HasKey(u => u.Id);
                options.Property(u => u.Id)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Campus>(options =>
            {
                options.HasIndex(c => c.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Building>(options =>
            {
                options.HasKey(b => new
                {
                    b.Name,
                    b.CampusName
                });

                options.HasOne(b => b.Campus)
                    .WithMany(c => c.Buildings)
                    .HasForeignKey(b => b.CampusName)
                    .HasPrincipalKey(c => c.Name)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Room>(options =>
            {
                options.HasKey(r =>
                    new
                    {
                        r.Number,
                        r.DetailsId
                    });

                options.Property(r => r.Id).ValueGeneratedOnAdd();
                options.HasAlternateKey(r => r.Id);

                options.HasOne(r => r.Details)
                    .WithMany(b => b.Rooms)
                    .HasForeignKey(r => r.DetailsId)
                    .HasPrincipalKey(b => b.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                // This Converter will perform the conversion to and from Json to the desired type
                options.Property(e => e.Points).HasConversion(
                    v => JsonConvert.SerializeObject(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}),
                    v => JsonConvert.DeserializeObject<ICollection<Point>>(v,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
            });

            modelBuilder.Entity<Floor>(options =>
            {
                options.HasKey(f =>
                    new
                    {
                        f.Number,
                        f.Order
                    });
            });

            modelBuilder.Entity<BuildingContents>(options =>
            {
                options.Property(r => r.Id).ValueGeneratedOnAdd();

                options.HasKey(e => new
                    {
                        e.CampusName,
                        e.BuildingName,
                        e.FloorNumber
                    });

                options.HasOne(e => e.Building)
                    .WithMany(b => b.Contents)
                    .HasForeignKey(e => new
                    {
                        e.CampusName,
                        e.BuildingName
                    })
                    .HasPrincipalKey(b => new
                    {
                        b.CampusName,
                        b.Name
                    })
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                options.HasOne(e => e.Floor)
                    .WithMany()
                    .HasForeignKey(e => e.FloorNumber)
                    .HasPrincipalKey(f => f.Number)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Reservation>(options =>
            {
                options.HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                options.HasOne(r => r.Room)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.RoomId)
                    .HasPrincipalKey(r => r.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Report>(options =>
            {
                options.HasOne(r => r.User)
                    .WithMany()
                    .HasForeignKey(r => r.UserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasOne(r => r.Room)
                    .WithMany()
                    .HasForeignKey(r => r.RoomId)
                    .HasPrincipalKey(r => r.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Picture>(options =>
            {
                options.HasOne(p => p.Report)
                    .WithMany(r => r.Pictures)
                    .HasForeignKey(p => p.ReportId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Notification>(options =>
            {
                options.HasKey(n => n.Id);
                options.Property(n => n.Id)
                    .ValueGeneratedOnAdd();
                options.Property(n => n.CreatedDate)
                    .HasDefaultValueSql("getdate()");
                options.Property(n => n.IsNew)
                    .HasDefaultValue(true);
            });

            // Seed sample data
            modelBuilder.Seed();
        }
        public DbSet<User> User { get; set; }

    }
}