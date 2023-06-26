using GuideService.API.Models.PhoneNumber;

namespace GuideService.API.Models.Person
{
    public class PersonModel : ModelBase
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public List<PhoneNumberModel> phoneNumbers { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
