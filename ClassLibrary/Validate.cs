using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Validate
    {
        //instance object of regex class with regular expression patterns to be check
        public static Regex regex_Numbers = new Regex("[0-9]+");//numbers
        public static Regex regex_UpperCase = new Regex(@"[A-Z]+");//uppercase
        public static Regex regex_LowerCase = new Regex(@"[a-z]+");//lowercase
        public static Regex regex_SpecialCharacter = new Regex(@"[!@#$%^&^()_+=\[{\]};:<>|./?,-]+");//special character
        public static Regex regex_email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");//email
        public static Regex regex_UnderScore = new Regex("_.*");//underscore

        //boolean varibales
        static Boolean numbers = false;
        static Boolean email_check = false;
        static Boolean UnderScore = false;
        static Boolean lowerCase = false;
        public static Boolean checkRegistration = false;
        public static Boolean checkResetPassword = false;

        //method to check first, last name for number and special characters
        public static Boolean CheckNames(string firstName, string lastName)
        {


            if (regex_Numbers.IsMatch(firstName) || regex_Numbers.IsMatch(lastName) || regex_SpecialCharacter.IsMatch(firstName) || regex_SpecialCharacter.IsMatch(lastName))
            {
                numbers = false;

            }
            else
            {
                numbers = true;


            }

            return numbers;
        }//************************************************************************[E]

        //method to check email
        public static Boolean CheckEmail(string email)
        {
            if (regex_email.IsMatch(email))
            {
                email_check = true;
            }
            else
            {
                email_check = false;
            }

            return email_check;
        }//*************************************************************************[E]

        //method to check username
        public static Boolean CheckUserName(string userName)
        {
            if (regex_UnderScore.IsMatch(userName) && userName.Length == 8)
            {
                UnderScore = true;
            }
            else
            {
                UnderScore = false;
            }
            return UnderScore;
        }//*************************************************************************[E]
        //method to check password
        public static Boolean CheckPassword(string password)
        {
            if (regex_LowerCase.IsMatch(password) && regex_UpperCase.IsMatch(password) && regex_Numbers.IsMatch(password) && regex_SpecialCharacter.IsMatch(password) && password.Length >= 8)
            {
                lowerCase = true;


            }
            else
            {
                lowerCase = false;

                //MessageBox.Show("Password is not correctly formatted, Please ensure that the password contains:\nAt least 8 characters\nA capital letter\nA lowercase letter\nA number \nA special character.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return lowerCase;
        }
        //method to everything
        public static Boolean Register_User(string firstName, string lastName, string email, string userName, string password, string txtbox_userName)
        {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            string message;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            if (!CheckNames(firstName, lastName))
            {
                message = "First or Last Name contains a number or special characters ensure to remove such";

            }
            if (!CheckEmail(email))
            {

                message = "Please enter a valid email address, Invalid email format, Missing '@' symbol, Invalid domain name.";

            }
            if (!CheckUserName(userName))
            {
                message = "Username is not correctly formatted,\nPlease ensure that your username contains an underscore\nAnd is no more than 8 characters in length ";

            }
            if (!CheckPassword(password))
            {
                message = "Password is not correctly formatted, Please ensure that the password contains:\nAt least 8 characters\nA capital letter\nA lowercase letter\nA number \nA special character.";

            }
            if (CheckNames(firstName, lastName) && CheckEmail(email) && CheckUserName(userName) && CheckPassword(password))
            {
                InsertInto.Connection.Close();


                InsertInto.InsertUser(firstName, lastName, email, userName, password, txtbox_userName);

                checkRegistration = true;
            }

            
            return checkRegistration;
        }
        public static Boolean ResetPassword(string resetUser_newPassword, string resetUser_EmailUsername)
        {
            if (CheckPassword(resetUser_newPassword))
            {

                InsertInto.resetPassword(resetUser_newPassword, resetUser_EmailUsername);

                checkResetPassword = true;

            }

            return checkResetPassword;
        }
    }
}
