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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options => 
            {
                options.HasKey(u => u.Number);

                // Turn of the automatic generation of PK.
                // This way so we can create users with their Number from the FontysAPI.
                options.Property(u => u.Number)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Room>(options =>
            {
                options.HasIndex(r => r.Number).IsUnique();
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
                    .HasForeignKey(r => r.UserNumber)
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
