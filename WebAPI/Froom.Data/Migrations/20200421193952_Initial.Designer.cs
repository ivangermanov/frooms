﻿// <auto-generated />
using System;
using Froom.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Froom.Data.Migrations
{
    [DbContext(typeof(FroomContext))]
    [Migration("20200421193952_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Froom.Data.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CampusName");

                    b.ToTable("Building");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "R1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "R3R4"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "R5"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "EK"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "ER"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "ES"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "S1"
                        },
                        new
                        {
                            Id = 8,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "S2"
                        },
                        new
                        {
                            Id = 9,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "S3"
                        },
                        new
                        {
                            Id = 10,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "TF"
                        },
                        new
                        {
                            Id = 11,
                            Address = "Unknown",
                            CampusName = "EHV",
                            Name = "TQ"
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.BuildingContents", b =>
                {
                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FloorNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("BuildingName", "FloorNumber");

                    b.HasIndex("FloorNumber");

                    b.ToTable("BuildingContents");

                    b.HasData(
                        new
                        {
                            BuildingName = "R1",
                            FloorNumber = "BG",
                            Id = 1
                        },
                        new
                        {
                            BuildingName = "R1",
                            FloorNumber = "1e",
                            Id = 2
                        },
                        new
                        {
                            BuildingName = "R1",
                            FloorNumber = "2e",
                            Id = 3
                        },
                        new
                        {
                            BuildingName = "R1",
                            FloorNumber = "3e",
                            Id = 4
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

                    b.Property<int?>("UserNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserNumber");

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

                    b.Property<int>("UserNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserNumber");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            RoomId = 1,
                            StartTime = new DateTime(2020, 5, 5, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            UserNumber = 4516348
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
                            Number = "40",
                            DetailsId = 3,
                            Capacity = 40,
                            Id = 1
                        },
                        new
                        {
                            Number = "10",
                            DetailsId = 3,
                            Capacity = 10,
                            Id = 2
                        },
                        new
                        {
                            Number = "05",
                            DetailsId = 3,
                            Capacity = 30,
                            Id = 3
                        },
                        new
                        {
                            Number = "03",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 4
                        },
                        new
                        {
                            Number = "71",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 5
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.User", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Number = 3947204,
                            Name = "Ruthyn, Maud",
                            Role = 0
                        },
                        new
                        {
                            Number = 7492568,
                            Name = "Ruthyn, Silas",
                            Role = 0
                        },
                        new
                        {
                            Number = 2475253,
                            Name = "Knollys, Monica",
                            Role = 0
                        },
                        new
                        {
                            Number = 8538245,
                            Name = "Toole, Larry",
                            Role = 0
                        },
                        new
                        {
                            Number = 1274628,
                            Name = "O'Connor, Edmond",
                            Role = 0
                        },
                        new
                        {
                            Number = 4516348,
                            Name = "Ashwoode, Mary",
                            Role = 0
                        },
                        new
                        {
                            Number = 3638459,
                            Name = "Karnstein, Mircalla",
                            Role = 0
                        },
                        new
                        {
                            Number = 3634571,
                            Name = "Brice, Tom",
                            Role = 0
                        },
                        new
                        {
                            Number = 7245343,
                            Name = "Hawkes, Meg",
                            Role = 0
                        },
                        new
                        {
                            Number = 3635673,
                            Name = "Cresswell, Penrose",
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
                    b.HasOne("Froom.Data.Entities.Building", "Building")
                        .WithMany("Contents")
                        .HasForeignKey("BuildingName")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Froom.Data.Entities.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorNumber")
                        .HasPrincipalKey("Number")
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Froom.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserNumber")
                        .OnDelete(DeleteBehavior.SetNull);
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
                        .HasForeignKey("UserNumber")
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
