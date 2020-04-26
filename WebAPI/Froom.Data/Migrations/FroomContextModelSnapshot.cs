﻿// <auto-generated />
using System;
using Froom.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Froom.Data.Migrations
{
    [DbContext(typeof(FroomContext))]
    partial class FroomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Froom.Data.Entities.Building", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CampusName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Name", "CampusName");

                    b.ToTable("Building");

                    b.HasData(
                        new
                        {
                            Name = "R1",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 1
                        },
                        new
                        {
                            Name = "R3R4",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 2
                        },
                        new
                        {
                            Name = "R5",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 3
                        },
                        new
                        {
                            Name = "EK",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 4
                        },
                        new
                        {
                            Name = "ER",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 5
                        },
                        new
                        {
                            Name = "ES",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 6
                        },
                        new
                        {
                            Name = "S1",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 7
                        },
                        new
                        {
                            Name = "S2",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 8
                        },
                        new
                        {
                            Name = "S3",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 9
                        },
                        new
                        {
                            Name = "TF",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 10
                        },
                        new
                        {
                            Name = "TQ",
                            CampusName = "EHV",
                            Address = "Unknown",
                            Id = 11
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.BuildingContents", b =>
                {
                    b.Property<string>("CampusName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FloorNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CampusName", "BuildingName", "FloorNumber");

                    b.HasIndex("FloorNumber");

                    b.ToTable("BuildingContents");

                    b.HasData(
                        new
                        {
                            CampusName = "EHV",
                            BuildingName = "R1",
                            FloorNumber = "BG",
                            Id = 1
                        },
                        new
                        {
                            CampusName = "EHV",
                            BuildingName = "R1",
                            FloorNumber = "1e",
                            Id = 2
                        },
                        new
                        {
                            CampusName = "EHV",
                            BuildingName = "R1",
                            FloorNumber = "2e",
                            Id = 3
                        },
                        new
                        {
                            CampusName = "EHV",
                            BuildingName = "R1",
                            FloorNumber = "3e",
                            Id = 4
                        },
                        new
                        {
                            CampusName = "EHV",
                            BuildingName = "R1",
                            FloorNumber = "4e",
                            Id = 5
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Campus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "EHV"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TIL"
                        },
                        new
                        {
                            Id = 3,
                            Name = "VNL"
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.Floor", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Number", "Order");

                    b.ToTable("Floor");

                    b.HasData(
                        new
                        {
                            Number = "BG",
                            Order = 0
                        },
                        new
                        {
                            Number = "1e",
                            Order = 1
                        },
                        new
                        {
                            Number = "2e",
                            Order = 2
                        },
                        new
                        {
                            Number = "3e",
                            Order = 3
                        },
                        new
                        {
                            Number = "4e",
                            Order = 4
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Froom.Data.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Froom.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            RoomId = 1,
                            StartTime = new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("e35e511a-1edf-4079-9b8e-39a4cf37310b")
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.Room", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DetailsId")
                        .HasColumnType("int");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Points")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number", "DetailsId");

                    b.HasIndex("DetailsId");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Number = "0.183",
                            DetailsId = 1,
                            Capacity = 40,
                            Id = 1,
                            Points = "[{\"X\":68.730469,\"Y\":-4.915833},{\"X\":40.253906,\"Y\":-5.615986},{\"X\":40.78125,\"Y\":3.864255},{\"X\":68.90625,\"Y\":3.688855},{\"X\":68.730469,\"Y\":24.686952},{\"X\":97.558594,\"Y\":24.686952},{\"X\":97.558594,\"Y\":-4.915833},{\"X\":68.730469,\"Y\":-4.915833}]"
                        },
                        new
                        {
                            Number = "1.19",
                            DetailsId = 2,
                            Capacity = 10,
                            Id = 2,
                            Points = "[{\"X\":-151.083984,\"Y\":-67.474922},{\"X\":-151.083984,\"Y\":-51.508742},{\"X\":-129.199219,\"Y\":-51.508742},{\"X\":-129.199219,\"Y\":-67.474922},{\"X\":-151.083984,\"Y\":-67.474922}]"
                        },
                        new
                        {
                            Number = "1.05",
                            DetailsId = 2,
                            Capacity = 30,
                            Id = 3,
                            Points = "[{\"X\":-216.210938,\"Y\":-64.586185},{\"X\":-183.691406,\"Y\":-56.12106},{\"X\":-183.691406,\"Y\":-64.586185},{\"X\":-216.210938,\"Y\":-64.586185}]"
                        },
                        new
                        {
                            Number = "2.24",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 4,
                            Points = "[{\"X\":-26.630859,\"Y\":-16.88866},{\"X\":-26.630859,\"Y\":5.528511},{\"X\":-5.361328,\"Y\":5.528511},{\"X\":-5.361328,\"Y\":-16.88866},{\"X\":-26.630859,\"Y\":-16.88866}]"
                        },
                        new
                        {
                            Number = "2.01",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 5,
                            Points = "[{\"X\":-37.353516,\"Y\":15.792254},{\"X\":-37.353516,\"Y\":35.532226},{\"X\":-15.380859,\"Y\":35.532226},{\"X\":-15.380859,\"Y\":15.792254},{\"X\":-37.353516,\"Y\":15.792254}]"
                        },
                        new
                        {
                            Number = "3.41",
                            DetailsId = 4,
                            Capacity = 50,
                            Id = 6,
                            Points = "[{\"X\":-151.347656,\"Y\":-58.35563},{\"X\":-151.347656,\"Y\":-36.031332},{\"X\":-129.550781,\"Y\":-36.031332},{\"X\":-129.550781,\"Y\":-58.35563},{\"X\":-151.347656,\"Y\":-58.35563}]"
                        },
                        new
                        {
                            Number = "3.44C",
                            DetailsId = 4,
                            Capacity = 20,
                            Id = 7,
                            Points = "[{\"X\":-49.042969,\"Y\":-58.263287},{\"X\":-49.042969,\"Y\":-41.640078},{\"X\":-25.3125,\"Y\":-41.640078},{\"X\":-25.3125,\"Y\":-58.263287},{\"X\":-49.042969,\"Y\":-58.263287}]"
                        },
                        new
                        {
                            Number = "4.109",
                            DetailsId = 5,
                            Capacity = 20,
                            Id = 8,
                            Points = "[{\"X\":-321.503906,\"Y\":56.848972},{\"X\":-334.160156,\"Y\":54.673831},{\"X\":-334.160156,\"Y\":38.272689},{\"X\":-321.679688,\"Y\":35.173808},{\"X\":-289.335938,\"Y\":35.029996},{\"X\":-287.578125,\"Y\":38.68551},{\"X\":-287.578125,\"Y\":42.811522},{\"X\":-288.808594,\"Y\":42.682435},{\"X\":-288.808594,\"Y\":57.984808},{\"X\":-287.578125,\"Y\":58.077876},{\"X\":-287.753906,\"Y\":67.339861},{\"X\":-295.664063,\"Y\":67.272043},{\"X\":-295.664063,\"Y\":62.593341},{\"X\":-302.871094,\"Y\":62.593341},{\"X\":-302.871094,\"Y\":56.752723},{\"X\":-321.503906,\"Y\":56.848972}]"
                        },
                        new
                        {
                            Number = "2.01",
                            DetailsId = 5,
                            Capacity = 20,
                            Id = 9,
                            Points = "[{\"X\":-203.90625,\"Y\":42.940339},{\"X\":-203.90625,\"Y\":57.326521},{\"X\":-183.339844,\"Y\":57.326521},{\"X\":-183.339844,\"Y\":42.940339},{\"X\":-203.90625,\"Y\":42.940339}]"
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e35e511a-1edf-4079-9b8e-39a4cf37310b"),
                            Name = "SeedUser",
                            Role = 0
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.Building", b =>
                {
                    b.HasOne("Froom.Data.Entities.Campus", "Campus")
                        .WithMany("Buildings")
                        .HasForeignKey("CampusName")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Froom.Data.Entities.BuildingContents", b =>
                {
                    b.HasOne("Froom.Data.Entities.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorNumber")
                        .HasPrincipalKey("Number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Froom.Data.Entities.Building", "Building")
                        .WithMany("Contents")
                        .HasForeignKey("CampusName", "BuildingName")
                        .HasPrincipalKey("CampusName", "Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Froom.Data.Entities.Picture", b =>
                {
                    b.HasOne("Froom.Data.Entities.Report", "Report")
                        .WithMany("Pictures")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Froom.Data.Entities.Report", b =>
                {
                    b.HasOne("Froom.Data.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Froom.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Froom.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Froom.Data.Entities.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Froom.Data.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Froom.Data.Entities.Room", b =>
                {
                    b.HasOne("Froom.Data.Entities.BuildingContents", "Details")
                        .WithMany("Rooms")
                        .HasForeignKey("DetailsId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
