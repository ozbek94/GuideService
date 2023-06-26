using AutoMapper;
using GuideService.API.Models.Person;
using GuideService.API.Models.phoneNumber;
using GuideService.API.Models.PhoneNumber;

namespace GuideService.API.Mappers.Person
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreationModel, GuideService.Domain.Entities.Person>();
            CreateMap<PhoneNumberCreationModel, GuideService.Domain.Entities.PhoneNumber>();
            CreateMap<GuideService.Domain.Entities.Person, PersonModel>();
            CreateMap<GuideService.Domain.Entities.PhoneNumber, PhoneNumberModel>();
        }

    }
}
