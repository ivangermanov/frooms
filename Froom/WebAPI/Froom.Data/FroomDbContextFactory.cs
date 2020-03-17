using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froom.Data
{
    #region snippet_IDbContextFactory
    public class FroomDbContextFactory : IDbContextFactory<FroomDbContext>
    {
        public FroomDbContext Create()
        {
            return new FroomDbContext();
        }
    }
    #endregion
}
