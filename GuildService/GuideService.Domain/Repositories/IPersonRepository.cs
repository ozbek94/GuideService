using GuideService.Domain.Entities;

namespace GuideService.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person Person);
        Task<List<Person>> GetPersons();
        Task<Person> GetPersonById(string Id);
        Task UpdatePerson(string Id, Person Person);
        Task DeletePerson(string Id);
        Task AddPhoneNumberToPerson(string PersonId, PhoneNumber phoneNumber);
        Task DeletePhoneNumberFromPerson(string PhoneNumberId);
    }
}
