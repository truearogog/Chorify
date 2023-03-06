using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Chorify.EntityFramework
{
    public class ChorifyDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ChorifyDbContext>
    {
        public ChorifyDbContext CreateDbContext(string[] args)
        {
            return new ChorifyDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Chorify.db").Options);
        }
    }
}
