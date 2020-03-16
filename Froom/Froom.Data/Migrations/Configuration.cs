using Froom.Data.Models;
using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Froom.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FroomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
        }

        protected override void Seed(FroomDbContext context)
        {
            // Adds some users with reservations to database
            GenerateIfNotExistUsersReservations(ref context);
        }
        private void GenerateIfNotExistUsersReservations(ref FroomDbContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                  new User { Id = 1, Number = 392845, Name = "Jane", Role = Role.Student },
                  new User { Id = 2, Number = 392855, Name = "Ivan", Role = Role.Teacher },
                  new User { Id = 3, Number = 392866, Name = "Anji", Role = Role.Admin }
                );

            context.Reservations.AddOrUpdate(x => x.Id,
                  new Reservation { Id = 1, UserId = 1, RoomName = "class"},
                  new Reservation { Id = 2, UserId = 2, RoomName = "lecture"}
                );
        }
    }
}

