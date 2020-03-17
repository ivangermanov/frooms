using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Froom.Data.Models;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data.Entity.Infrastructure;

namespace Froom.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FroomDbContext : DbContext
    {
        public FroomDbContext() : base("Server = studmysql01.fhict.local; Uid=dbi392854;Database=dbi392854;Pwd=Froom;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Reservation> Reservations { get; set; }
    }
}
