﻿using Microsoft.AspNetCore.Identity;

namespace JobPortalAPI.Model
{
    public class Employer
    {
        public int EmployerID { get; set; }
        public string EFirstName { get; set; }
        public string? EMiddleName { get; set; }
        public string ELastName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public long PhoneNumber { get; set; }
        public int? LoginId { get; set; }
        public int CompanyID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
