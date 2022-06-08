using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualTrading.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Pincode { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte[] UpdateDate { get; set; }
        public bool? Isactive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
