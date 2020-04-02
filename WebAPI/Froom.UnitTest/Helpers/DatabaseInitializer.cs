using Froom.Data.Database;
using Froom.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Froom.UnitTest.Helpers
{
    /// <summary>
    /// Initializes sample data to be used in the unit tests
    /// </summary>
    public static class DatabaseInitializer
    {
        private static EntityEntry<User> _createdNormalUser;

        private static EntityEntry<Building> _createdBuilding1;

        private static EntityEntry<Room> _createdRoom1;

        public static async Task Initialize(this FroomContext database)
        {
            await CreateUsers(database);
            await CreateBuildings(database);
            await CreateRooms(database);

            SeededData.NormalUser = _createdNormalUser.Entity;
            SeededData.Building1 = _createdBuilding1.Entity;
            SeededData.Room1 = _createdRoom1.Entity;
        }

        public static async Task CreateUsers(DbContext database)
        {
            var normalUser = new User()
            {
                Number = 386835,
                Name = "TestUser",
                Role = UserRole.NORMAL
            };

            _createdNormalUser = database.Set<User>().Add(normalUser);
            await database.SaveChangesAsync();
        }

        public static async Task CreateBuildings(DbContext database)
        {
            var building1 = new Building()
            {
                Name = "R1",
                Campus = "Fontys Rachelsmolen",
                Address = "Eindhoven, The Netherlands",
                Rooms = new List<Room>()
            };

            _createdBuilding1 = database.Set<Building>().Add(building1);
            await database.SaveChangesAsync();
        }

        public static async Task CreateRooms(DbContext database)
        {
            var room1 = new Room()
            {
                Number = "40",
                Floor = 2,
                Capacity = 40,
                Reservations = new List<Reservation>(),
                BuildingName = _createdBuilding1.Entity.Name,
                Points = new List<Point>()
                {
                    new Point() { X = 1.31, Y = 1.32 },
                    new Point() { X = 1.43, Y = 1.34 }
                }
            };

            _createdRoom1 = database.Set<Room>().Add(room1);
            await database.SaveChangesAsync();
        }
    }
}
