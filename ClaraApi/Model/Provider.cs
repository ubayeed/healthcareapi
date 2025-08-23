namespace ClaraApi.Model
{
    public class Provider
    {
        public int? ProviderId { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string NPINumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public List<Network> Networks { get; set; }
    }
}
