using System;
using System.Collections.Generic;
using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Database
{
    public static class ModelBuilderExtensions
    {
        private static readonly Guid userId = Guid.NewGuid();

        private static User[] Users
        {
            get
            {
                return new[]
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
                    new Building
                    {
                        Id = 2,
                        Name = "R3R4",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 3,
                        Name = "R5",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 4,
                        Name = "EK",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 5,
                        Name = "ER",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 6,
                        Name = "ES",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 7,
                        Name = "S1",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 8,
                        Name = "S2",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 9,
                        Name = "S3",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 10,
                        Name = "TF",
                        CampusName = "EHV",
                        Address = "Unknown"
                    },
                    new Building
                    {
                        Id = 11,
                        Name = "TQ",
                        CampusName = "EHV",
                        Address = "Unknown"
                    }
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
                            new Point {X = 68.730469, Y = -4.915833}, new Point {X = 40.253906, Y = -5.615986},
                            new Point {X = 40.78125, Y = 3.864255}, new Point {X = 68.90625, Y = 3.688855},
                            new Point {X = 68.730469, Y = 24.686952}, new Point {X = 97.558594, Y = 24.686952},
                            new Point {X = 97.558594, Y = -4.915833}, new Point {X = 68.730469, Y = -4.915833}
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
                            new Point {X = -151.083984, Y = -67.474922}, new Point {X = -151.083984, Y = -51.508742},
                            new Point {X = -129.199219, Y = -51.508742}, new Point {X = -129.199219, Y = -67.474922},
                            new Point {X = -151.083984, Y = -67.474922}
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
                            new Point {X = -216.210938, Y = -64.586185}, new Point {X = -183.691406, Y = -56.12106},
                            new Point {X = -183.691406, Y = -64.586185},
                            new Point {X = -216.210938, Y = -64.586185}
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
                            new Point {X = -26.630859, Y = -16.88866}, new Point {X = -26.630859, Y = 5.528511},
                            new Point {X = -5.361328, Y = 5.528511}, new Point {X = -5.361328, Y = -16.88866},
                            new Point {X = -26.630859, Y = -16.88866}
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
                            new Point {X = -37.353516, Y = 15.792254}, new Point {X = -37.353516, Y = 35.532226},
                            new Point {X = -15.380859, Y = 35.532226},
                            new Point {X = -15.380859, Y = 15.792254}, new Point {X = -37.353516, Y = 15.792254}
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
                            new Point {X = -151.347656, Y = -58.35563}, new Point {X = -151.347656, Y = -36.031332},
                            new Point {X = -129.550781, Y = -36.031332},
                            new Point {X = -129.550781, Y = -58.35563}, new Point {X = -151.347656, Y = -58.35563}
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
                            new Point {X = -49.042969, Y = -58.263287}, new Point {X = -49.042969, Y = -41.640078},
                            new Point {X = -25.3125, Y = -41.640078},
                            new Point {X = -25.3125, Y = -58.263287}, new Point {X = -49.042969, Y = -58.263287}
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
                            new Point {X = -321.503906, Y = 56.848972}, new Point {X = -334.160156, Y = 54.673831},
                            new Point {X = -334.160156, Y = 38.272689}, new Point {X = -321.679688, Y = 35.173808},
                            new Point {X = -289.335938, Y = 35.029996}, new Point {X = -287.578125, Y = 38.68551},
                            new Point {X = -287.578125, Y = 42.811522}, new Point {X = -288.808594, Y = 42.682435},
                            new Point {X = -288.808594, Y = 57.984808}, new Point {X = -287.578125, Y = 58.077876},
                            new Point {X = -287.753906, Y = 67.339861}, new Point {X = -295.664063, Y = 67.272043},
                            new Point {X = -295.664063, Y = 62.593341}, new Point {X = -302.871094, Y = 62.593341},
                            new Point {X = -302.871094, Y = 56.752723}, new Point {X = -321.503906, Y = 56.848972}
                        }
                    },
                    new Room
                    {
                        Id = 9,
                        Number = "2.01",
                        DetailsId = 5,
                        Capacity = 20,
                        Points = new List<Point>
                        {
                            new Point {X = -203.90625, Y = 42.940339}, new Point {X = -203.90625, Y = 57.326521},
                            new Point {X = -183.339844, Y = 57.326521},
                            new Point {X = -183.339844, Y = 42.940339}, new Point {X = -203.90625, Y = 42.940339}
                        }
                    }
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
                        UserId = userId,
                        RoomId = 1,
                        StartTime = DateTime.Parse("2020-05-05 08:45:00"),
                        Duration = TimeSpan.Parse("001:00:00")
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