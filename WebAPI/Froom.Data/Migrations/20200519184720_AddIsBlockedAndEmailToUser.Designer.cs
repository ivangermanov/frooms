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
    [Migration("20200519184720_AddIsBlockedAndEmailToUser")]
    partial class AddIsBlockedAndEmailToUser
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

            modelBuilder.Entity("Froom.Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Notification");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Message = "SeededNotification",
                            UserId = new Guid("468665e7-05ea-4210-92d2-96cf682131da")
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
                            UserId = new Guid("468665e7-05ea-4210-92d2-96cf682131da")
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
                            Points = "[{\"X\":68.378906,\"Y\":-4.039618},{\"X\":40.957031,\"Y\":-4.390229},{\"X\":40.78125,\"Y\":5.178482},{\"X\":68.818359,\"Y\":5.090944},{\"X\":68.554688,\"Y\":26.273714},{\"X\":97.207031,\"Y\":25.958045},{\"X\":97.558594,\"Y\":-3.688855},{\"X\":68.378906,\"Y\":-4.039618}]"
                        },
                        new
                        {
                            Number = "1.19",
                            DetailsId = 2,
                            Capacity = 10,
                            Id = 2,
                            Points = "[{\"X\":-151.347656,\"Y\":-69.349339},{\"X\":-150.996094,\"Y\":-55.875311},{\"X\":-128.847656,\"Y\":-56.170023},{\"X\":-128.847656,\"Y\":-69.472969}]"
                        },
                        new
                        {
                            Number = "1.05",
                            DetailsId = 2,
                            Capacity = 30,
                            Id = 3,
                            Points = "[{\"X\":-216.738281,\"Y\":-67.101656},{\"X\":-216.650391,\"Y\":-60.020952},{\"X\":-183.867187,\"Y\":-60.152442},{\"X\":-183.691406,\"Y\":-66.998844}]"
                        },
                        new
                        {
                            Number = "2.24",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 4,
                            Points = "[{\"X\":-26.367188,\"Y\":-33.137551},{\"X\":-26.71875,\"Y\":-12.726084},{\"X\":-5.449219,\"Y\":-12.726084},{\"X\":-5.273438,\"Y\":-34.016242},{\"X\":-26.367188,\"Y\":-33.137551}]"
                        },
                        new
                        {
                            Number = "2.01",
                            DetailsId = 3,
                            Capacity = 20,
                            Id = 5,
                            Points = "[{\"X\":-37.265625,\"Y\":-2.108899},{\"X\":-37.265625,\"Y\":19.642588},{\"X\":-14.765625,\"Y\":19.311143},{\"X\":-15.46875,\"Y\":-2.460181},{\"X\":-37.265625,\"Y\":-2.108899}]"
                        },
                        new
                        {
                            Number = "3.41",
                            DetailsId = 4,
                            Capacity = 50,
                            Id = 6,
                            Points = "[{\"X\":-150.820312,\"Y\":-66.372755},{\"X\":-150.996094,\"Y\":-49.61071},{\"X\":-129.19921,\"Y\":-49.496675},{\"X\":-129.199219,\"Y\":-66.302205},{\"X\":-150.820312,\"Y\":-66.372755}]"
                        },
                        new
                        {
                            Number = "3.44C",
                            DetailsId = 4,
                            Capacity = 20,
                            Id = 7,
                            Points = "[{\"X\":-48.691406,\"Y\":-66.372755},{\"X\":-48.515625,\"Y\":-53.956086},{\"X\":-25.3125,\"Y\":-53.748711},{\"X\":-25.3125,\"Y\":-66.443107},{\"X\":-48.691406,\"Y\":-66.372755}]"
                        },
                        new
                        {
                            Number = "4.109",
                            DetailsId = 5,
                            Capacity = 20,
                            Id = 8,
                            Points = "[{\"X\":-302.783203,\"Y\":45.336702},{\"X\":-321.416016,\"Y\":45.02695},{\"X\":-333.808594,\"Y\":42.488302},{\"X\":-333.896484,\"Y\":22.268764},{\"X\":-321.591797,\"Y\":18.979026},{\"X\":-288.984375,\"Y\":19.311143},{\"X\":-287.666016,\"Y\":22.674847},{\"X\":-287.578125,\"Y\":42.811522},{\"X\":-288.808594,\"Y\":42.682435},{\"X\":-289.072266,\"Y\":47.15984},{\"X\":-287.578125,\"Y\":47.338823},{\"X\":-287.666016,\"Y\":59.175928},{\"X\":-290.214844,\"Y\":59.085739},{\"X\":-295.400391,\"Y\":59.085739},{\"X\":-295.576172,\"Y\":52.855864},{\"X\":-302.783203,\"Y\":52.855864}]"
                        });
                });

            modelBuilder.Entity("Froom.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("468665e7-05ea-4210-92d2-96cf682131da"),
                            Email = "seeduser@gmail.com",
                            IsBlocked = false,
                            Name = "SeedUser",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("5c861938-98ba-41d2-9e24-da3610e34544"),
                            Email = "i.germanov@student.fontys.nl",
                            IsBlocked = false,
                            Name = "Ivan Germanov",
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("05847a38-8ea2-4232-966e-512d4159c554"),
                            Email = "y.buzykina@student.fontys.nl",
                            IsBlocked = false,
                            Name = "Yevheniia Buzykina",
                            Role = 1
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
