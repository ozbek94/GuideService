using GuideService.Domain.Repositories;

namespace GuideService.Domain.Services
{
    public interface IDataServices
    {
        public IPersonRepository Persons { get; }
    }
}
