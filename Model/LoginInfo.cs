﻿namespace JobPortalAPI.Model
{
    public class LoginInfo
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int roleID { get; set; }
    }
}
