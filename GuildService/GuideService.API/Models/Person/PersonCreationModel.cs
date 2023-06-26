using GuideService.API.Models.phoneNumber;

namespace GuideService.API.Models.Person
{
    public class PersonCreationModel
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public List<PhoneNumberCreationModel> phoneNumbers { get; set; }
        public string Description { get; set; }
    }
}
