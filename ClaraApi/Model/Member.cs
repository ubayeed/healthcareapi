namespace ClaraApi.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string GroupId { get; set; }
        public int PayorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string StreetAddress1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double CurrentPaidDeductible { get; set; }
        public int EligibilityValid { get; set; }
        public double MaxOutOfPocket { get; set; }
        public double Copay { get; set; }
    }
}
