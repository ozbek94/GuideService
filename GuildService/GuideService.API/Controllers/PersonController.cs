using AutoMapper;
using GuideService.API.Models.Person;
using GuideService.Domain.Entities;
using GuideService.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuideService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonCreationModel Model)
        {
            var person = _mapper.Map<Person>(Model);
            await _personRepository.CreatePerson(person);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _personRepository.GetPersons();
            var model = _mapper.Map<List<PersonModel>>(persons);
            
            return Ok(model);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPersonById(string Id)
        {
            var person = await _personRepository.GetPersonById(Id);
            var model = _mapper.Map<PersonModel>(person);

            return Ok(model);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdeatePerson(string Id, PersonCreationModel Model)
        {
            var person = _mapper.Map<Person>(Model);
            await _personRepository.UpdatePerson(Id, person);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePerson(string Id)
        {
            await _personRepository.DeletePerson(Id);

            return Ok();
        }

        [HttpPost("PhoneNumber")]
        public async Task<IActionResult> AddPhoneNumberToPerson(PhoneForPersonCreationModel Model)
        {
            var phoneNumber = _mapper.Map<PhoneNumber>(Model.PhoneNumber);
            await _personRepository.AddPhoneNumberToPerson(Model.PersonId, phoneNumber);

            return Ok();
        }

        [HttpDelete("PhoneNumber")]
        public async Task<IActionResult> DeletePhoneNumberFromPerson(PhoneNumberDeleteFromPersonModel Model)
        {
            await _personRepository.DeletePhoneNumberFromPerson(Model.PhoneNumberId);

            return Ok();
        }
    }
}
