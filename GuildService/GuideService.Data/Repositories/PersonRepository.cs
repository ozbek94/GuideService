using GuideService.Domain.Entities;
using GuideService.Domain.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GuideService.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonRepository(IMongoDatabase database)
        {
            _persons = database.GetCollection<Person>("Persons");
        }

        public async Task AddPhoneNumberToPerson(string PersonId, PhoneNumber phoneNumber)
        {
            phoneNumber.Id = ObjectId.GenerateNewId().ToString();

            var filter = Builders<Person>.Filter.Eq(x => x.Id, PersonId);
            var update = Builders<Person>.Update.Push(x => x.PhoneNumbers, phoneNumber);

            await _persons.UpdateOneAsync(filter, update);
        }

        public async Task CreatePerson(Person Person)
        {
            foreach (var phoneNumber in Person.PhoneNumbers)
            {
                phoneNumber.Id = ObjectId.GenerateNewId().ToString();
            }

            await _persons.InsertOneAsync(Person);
        }

        public async Task DeletePerson(string Id)
        {
            var filter = Builders<Person>.Filter.Eq(p => p.Id, Id);

            await _persons.DeleteOneAsync(filter);
        }

        public async Task DeletePhoneNumberFromPerson(string PhoneNumberId)
        {
            var filter = Builders<Person>.Filter.ElemMatch(k => k.PhoneNumbers, n => n.Id == PhoneNumberId);
            var update = Builders<Person>.Update.PullFilter(k => k.PhoneNumbers, n => n.Id == PhoneNumberId);

            await _persons.UpdateOneAsync(filter, update);
        }

        public async Task<Person> GetPersonById(string Id)
        {
            var person = await _persons.Find(x => x.Id == Id).FirstOrDefaultAsync();

            return person;
        }

        public async Task<List<Person>> GetPersons()
        {
            var persons = await _persons.AsQueryable().ToListAsync();
            return persons;
        }

        public async Task UpdatePerson(string Id, Person Person)
        {
            foreach (var phoneNumber in Person.PhoneNumbers)
            {
                phoneNumber.Id = ObjectId.GenerateNewId().ToString();
            }

            var filter = Builders<Person>.Filter.Eq(x => x.Id, Id);

            var update = Builders<Person>.Update
                .Set(p => p.Firstname, Person.Firstname)
                .Set(p => p.LastName, Person.LastName)
                .Set(P => P.Description, Person.Description)
                .Set(p => p.PhoneNumbers, Person.PhoneNumbers);

            await _persons.UpdateOneAsync(filter, update);
        }
    }
}
