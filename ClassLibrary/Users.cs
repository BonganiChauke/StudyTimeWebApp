using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Users
    {
        //automatic properties
        public string? FIRSTNAME
        {
            get; set;
        }

        public string? LASTNAME
        {
            get; set;
        }

        public string? EMAIL
        {
            get; set;
        }

        public string? USERNAME
        {
            get; set;
        }

        public string? PASSWORD
        {
            get; set;
        }

        public string? CONFIRM_PASSWORD
        {
            get; set;
        }

        public Users() { }

        public Users(string firstName, string lastName, string email, string userName, string password, string confirm_password)
        {
            FIRSTNAME = firstName;
            LASTNAME = lastName;
            EMAIL = email;
            USERNAME = userName;
            PASSWORD = password;
            CONFIRM_PASSWORD = confirm_password;
        }
    }
}
