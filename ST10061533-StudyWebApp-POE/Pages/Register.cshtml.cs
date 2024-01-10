using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace ST10061533_StudyWebApp_POE.Pages
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
        //List<Modules> moduleObj = new List<Modules>();//Declaring the class module as a list
        List<Users> userObj = new List<Users>();//

        //decalring a class object
        Users? userClassList;

        //declaring variables 
        public string firstName = "", lastName = "", email = "", userName = "", password = "", confirm_password = "", txtbox_userName = "", message = "";
        //public Boolean check = false;

        public void OnPost()
        {
            //try catch to handle errors
            try
            {
                //variables to store user input
                firstName = Request.Form["FirstName"];
                lastName = Request.Form["LastName"];
                email = Request.Form["Email"];
                userName = Request.Form["UserName"];
                password = Request.Form["Password"];
                confirm_password = Request.Form["ConfirmPassword"];

                //Adding to the list object and constructor
                userClassList = new Users(firstName, lastName, email, userName, password, confirm_password);
                userObj.Add(userClassList);

                //if checks the register if its true meaning the user has succesful registered without errors
                if (Validate.Register_User(firstName, lastName, email, userName, password, txtbox_userName))
                {
                    Validate.checkRegistration = true;
                    message = "Succussful Registration Welocome User";
                    Response.Redirect("/Login");
                }
                //else if the register method is not true and registration has failed
                else if (!Validate.Register_User(firstName, lastName, email, userName, password, txtbox_userName))
                {
                    Validate.checkRegistration = false;
                    message = "Registration Failed: Reasons\nFirst Name or Last Name contains numbers or special\nUsername is not 8 characters long and does not contain an underscore\nPassword is not more than 8 characters long, does not have a lower case letter, upper case letter, a number or special characters";
                }


            }
            //sql exception to handle sql errors
            catch (SqlException ex)
            {
                //check for duplicate with primary 
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    if (ex.Message.Contains("unique"))
                    {
                        message = "This username already exists please create a unique username";
                    }
                    else
                    {
                        message = "This username already exists please create a unique username";
                    }
                }
                else
                {
                    //any other sql errors
                    message = ex.Message;
                }

            }
            //catch any error
            catch (Exception Error)
            {
                message = Error.Message;
            }



        }
    }
}
