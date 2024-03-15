namespace JobPortalAPI.Model
{
    public class Jobseekers
    {
        public int SeekerId { get; set; }
        public string SFirstName { get; set; }
        public string? SMiddleName { get; set; }
        public string SLastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string WorkStatus { get; set; }
        public int? LoginId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
