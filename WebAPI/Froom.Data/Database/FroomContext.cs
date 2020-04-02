using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Froom.Data.Database
{
    public class FroomContext : DbContext
    {
        public FroomContext(DbContextOptions<FroomContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options => { options.HasKey(u => u.Number); });

            modelBuilder.Entity<Room>(options =>
            {
                options.HasOne(r => r.Building)
                    .WithMany(b => b.Rooms)
                    .HasForeignKey(r => r.BuildingName)
                    .HasPrincipalKey(b => b.Name)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                // This Converter will perform the conversion to and from Json to the desired type
                options.Property(e => e.Points).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<ICollection<Point>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            });

            modelBuilder.Entity<Reservation>(options =>
            {
                options.HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserNumber)
                    .HasPrincipalKey(u => u.Number)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasOne(r => r.Room)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.RoomId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Report>(options =>
            {
                options.HasOne(r => r.User)
                    .WithMany()
                    .HasForeignKey(r => r.Id)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasOne(r => r.Room)
                    .WithMany()
                    .HasForeignKey(r => r.RoomId)
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
        }

    }
}
