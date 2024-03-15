namespace JobPortalAPI.Model
{
    public class CompanyDetails
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int StartEmployeeRange { get; set; }
        public long EndEmployeeRange { get; set; }
        public string CAddress { get; set; }
    }
}
