using GuideService.Data.Contexts;
using GuideService.Data.Repositories;
using GuideService.Domain.Repositories;
using GuideService.Domain.Services;

namespace GuideService.Data.Services
{
    public class DataServices : IDataServices
    {
        private readonly MongoDbContext _dbContext;

        public DataServices(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPersonRepository Persons => new PersonRepository(_dbContext.Database);
    }
}
