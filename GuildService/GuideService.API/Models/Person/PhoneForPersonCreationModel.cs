using GuideService.API.Models.phoneNumber;

namespace GuideService.API.Models.Person
{
    public class PhoneForPersonCreationModel
    {
        public string PersonId { get; set; }
        public PhoneNumberCreationModel PhoneNumber { get; set; }
    }
}
