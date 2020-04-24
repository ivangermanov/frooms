using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Froom.Data.Database
{
    public static class ModelBuilderExtensions
    {
        private readonly static Guid userId = Guid.NewGuid();

        // Sample data for the seeding
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(Users);
            modelBuilder.Entity<Campus>().HasData(Campuses);
            modelBuilder.Entity<Building>().HasData(Buildings);
            modelBuilder.Entity<Floor>().HasData(Floors);
            modelBuilder.Entity<BuildingContents>().HasData(BuildingFloorRooms_Relationship);
            modelBuilder.Entity<Room>().HasData(Rooms);
            modelBuilder.Entity<Reservation>().HasData(Reservations);
        }

        private static User[] Users
        {
            get
            {
                return new User[]
                {
                    new User
                    {
                        Id = userId,
                        Name = "SeedUser",
                        Role = UserRole.NORMAL
                    }
                };
            }
        }

        private static Campus[] Campuses
        {
            get
            {
                return new Campus[]
                {
                    new Campus { Id = 1, Name = "EHV" },
                    new Campus { Id = 2, Name = "TIL" },
                    new Campus { Id = 3, Name = "VNL" }
                };
            }
        }

        private static Building[] Buildings
        {
            get
            {
                return new Building[]
                {
                    new Building
                    {
                        Id = 1,
                        Name = "R1",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 2,
                        Name = "R3R4",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 3,
                        Name = "R5",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 4,
                        Name = "EK",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 5,
                        Name = "ER",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 6,
                        Name = "ES",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 7,
                        Name = "S1",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 8,
                        Name = "S2",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 9,
                        Name = "S3",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 10,
                        Name = "TF",
                        CampusName = "EHV",
                        Address = "Unknown",
                    },
                    new Building
                    {
                        Id = 11,
                        Name = "TQ",
                        CampusName = "EHV",
                        Address = "Unknown",
                    }
                };
            }
        }

        private static Floor[] Floors
        {
            get
            {
                return new Floor[]
                {
                    new Floor
                    {
                        Number = "BG",
                        Order = 0
                    },
                    new Floor
                    {
                        Number = "1e",
                        Order = 1
                    },
                    new Floor
                    {
                        Number = "2e",
                        Order = 2
                    },
                    new Floor
                    {
                        Number = "3e",
                        Order = 3
                    },
                    new Floor
                    {
                        Number = "4e",
                        Order = 4
                    }
                };
            }
        }

        private static BuildingContents[] BuildingFloorRooms_Relationship
        {
            get
            {
                return new BuildingContents[]
                {
                    new BuildingContents
                    {
                        Id = 1,
                        BuildingName = "R1",
                        FloorNumber = "BG",
                        CampusName = "EHV"
                    },
                    new BuildingContents
                    {
                        Id = 2,
                        BuildingName = "R1",
                        FloorNumber = "1e",
                        CampusName = "EHV"
                    },
                    new BuildingContents
                    {
                        Id = 3,
                        BuildingName = "R1",
                        FloorNumber = "2e",
                        CampusName = "EHV"
                    },
                    new BuildingContents
                    {
                        Id = 4,
                        BuildingName = "R1",
                        FloorNumber = "3e",
                        CampusName = "EHV"
                    }
                };
            }
        }

        private static Room[] Rooms
        {
            get
            {
                return new Room[]
                {
                    new Room
                    {
                        Id = 1,
                        Number = "40",
                        DetailsId = 3,
                        Capacity = 40
                    },
                    new Room
                    {
                        Id = 2,
                        Number = "10",
                        DetailsId = 3,
                        Capacity = 10
                    },
                    new Room
                    {
                        Id = 3,
                        Number = "05",
                        DetailsId = 3,
                        Capacity = 30
                    },
                    new Room
                    {
                        Id = 4,
                        Number = "03",
                        DetailsId = 3,
                        Capacity = 20
                    },
                    new Room
                    {
                        Id = 5,
                        Number = "71",
                        DetailsId = 3,
                        Capacity = 20
                    }
                };
            }
        }

        private static Reservation[] Reservations
        {
            get
            {
                return new Reservation[]
                {
                    new Reservation
                    {
                        Id = 1,
                        UserId = userId,
                        RoomId = 1,
                        StartTime = DateTime.Parse("2020-05-05 08:45:00"),
                        Duration = TimeSpan.Parse("001:00:00")
                    }
                };
            }
        }
    }
}
