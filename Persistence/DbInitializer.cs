using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(UserDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
