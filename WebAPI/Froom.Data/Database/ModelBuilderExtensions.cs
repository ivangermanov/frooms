using System;
using System.Collections.Generic;
using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Database
{
    public static class ModelBuilderExtensions
    {
        private static User[] Users
        {
            get
            {
                return new[]
                {
                    new User
                    {
                        Id = new Guid("5c861938-98ba-41d2-9e24-da3610e34544"),
                        Name = "Ivan Germanov",
                        Email = "i.germanov@student.fontys.nl",
                        Role = UserRole.ADMIN
                    },
                    new User
                    {
                        Id = new Guid("05847a38-8ea2-4232-966e-512d4159c554"),
                        Name = "Yevheniia Buzykina",
                        Email = "y.buzykina@student.fontys.nl",
                        Role = UserRole.ADMIN
                    },
                    new User
                    {
                        Id = new Guid("ab81a843-3e70-4cd2-9c89-d6b5719c3a6b"),
                        Name = "Anjela Melkonyan",
                        Email = "a.melkonyan@student.fontys.nl",
                        Role = UserRole.ADMIN
                    },
                    new User
                    {
                        Id = new Guid("AC408FF3-2E5D-4975-96A8-83E6E67F9E03"),
                        Name = "Chan,Jeffrey J.K.B.",
                        Email = "jeffrey.chan@student.fontys.nl",
                        Role = UserRole.ADMIN
                    }
                };
            }
        }

        private static Campus[] Campuses
        {
            get
            {
                return new[]
                {
                    new Campus {Id = 1, Name = "EHV"},
                    new Campus {Id = 2, Name = "TIL"},
                    new Campus {Id = 3, Name = "VNL"}
                };
            }
        }

        private static Building[] Buildings
        {
            get
            {
                return new[]
                {
                    new Building
                    {
                        Id = 1,
                        Name = "R1",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    //new Building
                    //{
                    //    Id = 2,
                    //    Name = "R3R4",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 3,
                    //    Name = "R5",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 4,
                    //    Name = "EK",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 5,
                    //    Name = "ER",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 6,
                    //    Name = "ES",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 7,
                    //    Name = "S1",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 8,
                    //    Name = "S2",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 9,
                    //    Name = "S3",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 10,
                    //    Name = "TF",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //},
                    //new Building
                    //{
                    //    Id = 11,
                    //    Name = "TQ",
                    //    CampusName = "EHV",
                    //    Address = "Unknown"
                    //}
                };
            }
        }

        private static Floor[] Floors
        {
            get
            {
                return new[]
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
                return new[]
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
                    },
                    new BuildingContents
                    {
                        Id = 5,
                        BuildingName = "R1",
                        FloorNumber = "4e",
                        CampusName = "EHV"
                    }
                };
            }
        }

        private static Room[] Rooms
        {
            get
            {
                return new[]
                {
                    new Room
                    {
                        Id = 1,
                        Number = "0.183",
                        DetailsId = 1,
                        Capacity = 40,
                        Points = new List<Point>
                        {
                            new Point {X = 68.378906, Y = -4.039618}, new Point {X = 40.957031, Y = -4.390229},
                            new Point {X = 40.78125, Y = 5.178482}, new Point {X = 68.818359, Y = 5.090944},
                            new Point {X = 68.554688, Y = 26.273714}, new Point {X = 97.207031, Y = 25.958045},
                            new Point {X = 97.558594, Y = -3.688855}, new Point {X = 68.378906, Y = -4.039618}
                        }
                    },
                    new Room
                    {
                        Id = 2,
                        Number = "1.19",
                        DetailsId = 2,
                        Capacity = 10,
                        Points = new List<Point>
                        {
                            new Point {X = -151.347656, Y = -69.349339}, new Point {X = -150.996094, Y = -55.875311},
                            new Point {X = -128.847656, Y = -56.170023}, new Point {X = -128.847656, Y = -69.472969}

                        }
                    },
                    new Room
                    {
                        Id = 3,
                        Number = "1.05",
                        DetailsId = 2,
                        Capacity = 30,
                        Points = new List<Point>
                        {
                            new Point {X = -216.738281, Y = -67.101656}, new Point {X = -216.650391, Y = -60.020952},
                            new Point {X = -183.867187, Y = -60.152442}, new Point {X = -183.691406, Y = -66.998844}
                        }
                    },
                    new Room
                    {
                        Id = 4,
                        Number = "2.24",
                        DetailsId = 3,
                        Capacity = 20,
                        Points = new List<Point>
                        {
                            new Point {X = -26.367188, Y = -33.137551}, new Point {X = -26.71875, Y = -12.726084},
                            new Point {X = -5.449219, Y = -12.726084}, new Point {X = -5.273438, Y = -34.016242},
                            new Point {X = -26.367188, Y = -33.137551}
                        }
                    },
                    new Room
                    {
                        Id = 5,
                        Number = "2.01",
                        DetailsId = 3,
                        Capacity = 20,
                        Points = new List<Point>
                        {
                            new Point {X = -37.265625, Y = -2.108899}, new Point {X = -37.265625, Y = 19.642588},
                            new Point {X = -14.765625, Y = 19.311143},
                            new Point {X = -15.46875, Y = -2.460181}, new Point {X = -37.265625, Y = -2.108899}
                        }
                    },
                    new Room
                    {
                        Id = 6,
                        Number = "3.41",
                        DetailsId = 4,
                        Capacity = 50,
                        Points = new List<Point>
                        {
                            new Point {X = -150.820312, Y = -66.372755}, new Point {X = -150.996094, Y = -49.61071},
                            new Point {X = -129.19921, Y = -49.496675},
                            new Point {X = -129.199219, Y = -66.302205}, new Point {X = -150.820312, Y = -66.372755}
                        }
                    },
                    new Room
                    {
                        Id = 7,
                        Number = "3.44C",
                        DetailsId = 4,
                        Capacity = 20,
                        Points = new List<Point>
                        {
                            new Point {X = -48.691406, Y = -66.372755}, new Point {X = -48.515625, Y = -53.956086},
                            new Point {X = -25.3125, Y = -53.748711},
                            new Point {X = -25.3125, Y = -66.443107}, new Point {X = -48.691406, Y = -66.372755}
                        }
                    },
                    new Room
                    {
                        Id = 8,
                        Number = "4.109",
                        DetailsId = 5,
                        Capacity = 20,
                        Points = new List<Point>
                        {
                            new Point {X = -302.783203, Y = 45.336702}, new Point {X = -321.416016, Y = 45.02695},
                            new Point {X = -333.808594, Y = 42.488302}, new Point {X = -333.896484, Y = 22.268764},
                            new Point {X = -321.591797, Y = 18.979026}, new Point {X = -288.984375, Y = 19.311143},
                            new Point {X = -287.666016, Y = 22.674847}, new Point {X = -287.578125, Y = 42.811522},
                            new Point {X = -288.808594, Y = 42.682435}, new Point {X = -289.072266, Y = 47.15984},
                            new Point {X = -287.578125, Y = 47.338823}, new Point {X = -287.666016, Y = 59.175928},
                            new Point {X = -290.214844, Y = 59.085739}, new Point {X = -295.400391, Y = 59.085739},
                            new Point {X = -295.576172, Y = 52.855864}, new Point {X = -302.783203, Y = 52.855864}
                        }
                    },
                };
            }
        }

        private static Reservation[] Reservations
        {
            get
            {
                return new[]
                {
                    new Reservation
                    {
                        Id = 1,
                        UserId = Users[0].Id,
                        RoomId = Rooms[0].Id,
                        StartDate = new DateTime(2020, 5, 5, 8, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 8, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 2,
                        UserId = Users[0].Id,
                        RoomId = Rooms[1].Id,
                        StartDate = new DateTime(2020, 5, 5, 9, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 9, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 3,
                        UserId = Users[0].Id,
                        RoomId = Rooms[2].Id,
                        StartDate = new DateTime(2020, 5, 5, 10, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 10, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 4,
                        UserId = Users[0].Id,
                        RoomId = Rooms[3].Id,
                        StartDate = new DateTime(2020, 5, 5, 11, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 11, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 5,
                        UserId = Users[0].Id,
                        RoomId = Rooms[0].Id,
                        StartDate = new DateTime(2020, 5, 5, 12, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 12, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 6,
                        UserId = Users[0].Id,
                        RoomId = Rooms[4].Id,
                        StartDate = new DateTime(2020, 5, 5, 13, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 13, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 7,
                        UserId = Users[1].Id,
                        RoomId = Rooms[5].Id,
                        StartDate = new DateTime(2020, 5, 5, 14, 0, 0),
                        EndDate = new DateTime(2020, 5, 5, 14, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 8,
                        UserId = Users[1].Id,
                        RoomId = Rooms[6].Id,
                        StartDate = new DateTime(2020, 5, 6, 8, 0, 0),
                        EndDate = new DateTime(2020, 5, 6, 8, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 9,
                        UserId = Users[1].Id,
                        RoomId = Rooms[7].Id,
                        StartDate = new DateTime(2020, 5, 6, 9, 0, 0),
                        EndDate = new DateTime(2020, 5, 6, 9, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 10,
                        UserId = Users[1].Id,
                        RoomId = Rooms[0].Id,
                        StartDate = new DateTime(2020, 5, 6, 10, 0, 0),
                        EndDate = new DateTime(2020, 5, 6, 10, 30, 0),
                    },

                    new Reservation
                    {
                        Id = 11,
                        UserId = Users[1].Id,
                        RoomId = Rooms[1].Id,
                        StartDate = new DateTime(2020, 5, 7, 8, 0, 0),
                        EndDate = new DateTime(2020, 5, 7, 8, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 12,
                        UserId = Users[2].Id,
                        RoomId = Rooms[2].Id,
                        StartDate = new DateTime(2020, 5, 7, 9, 0, 0),
                        EndDate = new DateTime(2020, 5, 7, 9, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 13,
                        UserId = Users[2].Id,
                        RoomId = Rooms[3].Id,
                        StartDate = new DateTime(2020, 5, 7, 10, 0, 0),
                        EndDate = new DateTime(2020, 5, 7, 10, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 14,
                        UserId = Users[2].Id,
                        RoomId = Rooms[4].Id,
                        StartDate = new DateTime(2020, 5, 7, 11, 0, 0),
                        EndDate = new DateTime(2020, 5, 7, 11, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 15,
                        UserId = Users[2].Id,
                        RoomId = Rooms[5].Id,
                        StartDate = new DateTime(2020, 5, 8, 8, 0, 0),
                        EndDate = new DateTime(2020, 5, 8, 8, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 16,
                        UserId = Users[2].Id,
                        RoomId = Rooms[6].Id,
                        StartDate = new DateTime(2020, 5, 8, 9, 0, 0),
                        EndDate = new DateTime(2020, 5, 8, 9, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 17,
                        UserId = Users[3].Id,
                        RoomId = Rooms[7].Id,
                        StartDate = new DateTime(2020, 5, 10, 8, 0, 0),
                        EndDate = new DateTime(2020, 5, 10, 8, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 18,
                        UserId = Users[3].Id,
                        RoomId = Rooms[0].Id,
                        StartDate = new DateTime(2020, 5, 10, 9, 0, 0),
                        EndDate = new DateTime(2020, 5, 10, 9, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 19,
                        UserId = Users[3].Id,
                        RoomId = Rooms[1].Id,
                        StartDate = new DateTime(2020, 5, 10, 10, 0, 0),
                        EndDate = new DateTime(2020, 5, 10, 10, 30, 0),
                    },
                    new Reservation
                    {
                        Id = 20,
                        UserId = Users[3].Id,
                        RoomId = Rooms[2].Id,
                        StartDate = new DateTime(2020, 5, 10, 11, 0, 0),
                        EndDate = new DateTime(2020, 5, 10, 11, 30, 0),
                    }
                };
            }
        }

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

    }
}