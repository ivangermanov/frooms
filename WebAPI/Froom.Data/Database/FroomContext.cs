﻿    using Froom.Data.Entities;
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

            modelBuilder.Entity<User>(options =>
            {
                options.HasIndex(u => new { u.Id, u.Number });
            });

            modelBuilder.Entity<Room>(options =>
            {
                options.HasIndex(r => r.Id);

                options.HasOne(r => r.Building)
                    .WithMany(b => b.Rooms)
                    .HasForeignKey(r => r.BuildingId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

                var valueComparer = new ValueComparer<ICollection<Point>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList());

                options.Property(e => e.Points)
                    .HasConversion(
                        v => JsonConvert
                                .SerializeObject(v,
                                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                        v => JsonConvert
                                .DeserializeObject<ICollection<Point>>(v,
                                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                    .Metadata.SetValueComparer(valueComparer);
            });

            modelBuilder.Entity<Building>(options =>
            {
                options.HasIndex(b => b.Id);
            });

            modelBuilder.Entity<Reservation>(options =>
            {
                options.HasIndex(r => r.Id);

                options.HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserId)
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
                options.HasKey(r => r.Id);

                options.HasOne(r => r.User)
                    .WithMany()
                    .HasForeignKey(r => r.UserId)
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
                options.HasKey(p => p.Id);

                options.HasOne(p => p.Report)
                    .WithMany(r => r.Pictures)
                    .HasForeignKey(p => p.ReportId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}