using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework
{
    public class ChorifyDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ChorifyDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ChorifyDbContext Create()
        {
            return new ChorifyDbContext(_options);
        }
    }
}
