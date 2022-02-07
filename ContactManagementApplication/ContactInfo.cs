using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagementApplication
{
    class ContactInfo
    {
        private string address, city, country, state, mobileNo, emailId;

        public ContactInfo()
        {

        }
        public ContactInfo(string address, string city, string country, string state, string mobileNo, string emailId)
        {
            this.address = address;
            this.city = city;
            this.country = country;
            this.state = state;
            this.mobileNo = mobileNo;
            this.emailId = emailId;
        }

        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public string Country { get => country; set => country = value; }
        public string State { get => state; set => state = value; }
        public string MobileNo { get => mobileNo; set => mobileNo = value; }
        public string EmailId { get => emailId; set => emailId = value; }
    }
}
