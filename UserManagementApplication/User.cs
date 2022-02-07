using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementApplication
{
    class User
    {
        private int userId;
        private string userName, dob, guardianName;
        private char gender;

        public User() {}
        public User(int userId, string userName, string dob, string guardianName, char gender)
        {
            this.userId = userId;
            this.userName = userName;
            this.dob = dob;
            this.guardianName = guardianName;
            this.gender = gender;
        }

        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Dob { get => dob; set => dob = value; }
        public string GuardianName { get => guardianName; set => guardianName = value; }
        public char Gender { get => gender; set => gender = value; }
    }
}
