using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories;
using Froom.UnitTest.Helpers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Froom.UnitTest.Data.RepositoryTests
{
    internal class RoomRepositoryTests : IDisposable
    {
        private RoomRepository _sut;
        private SqliteConnectionStringBuilder _connectionStringBuilder;
        private SqliteConnection _connection;
        private DbContextOptions<FroomContext> _options;

        [SetUp]
        public void Setup()
        {
            _connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            _connection = new SqliteConnection(_connectionStringBuilder.ToString());
            _options = new DbContextOptionsBuilder<FroomContext>().UseSqlite(_connection).Options;
        }

        [Test]
        public async Task AddAsync_ValidRoom_ShouldAddRoom()
        {
            Room newRoom;
            int numberOfRooms;

            using (var context = new FroomContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                await context.Initialize();

                numberOfRooms = await context.Set<Room>().CountAsync();

                newRoom = new Room()
                {
                    Number = "23",
                    Floor = 2,
                    Capacity = 20,
                    Reservations = new List<Reservation>(),
                    BuildingName = SeededData.Building1.Name,
                    Points = new List<Point>()
                    {
                        new Point() { X = 1.3, Y = 1.4 },
                        new Point() { X = 1.5, Y = 1.6 }
                    }
                };

                _sut = new RoomRepository(context);
                await _sut.AddAsync(newRoom);
            }

            using (var context = new FroomContext(_options))
            {
                Assert.That(await context.Set<Room>().CountAsync() == numberOfRooms + 1, "The fetched rooms count is not correct.");

                var result = context.Set<Room>().SingleAsync(r => r.Id == newRoom.Id);

                Assert.NotNull(result, "The fetched room was null.");
            }
        }


        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
