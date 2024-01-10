using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        //declaring variables
        public string userName = "", txtbox_password = "", message = "";
        public Boolean check = false;
        
        //on post method
        public void OnPost()
        {
            //try catch to handle errors
            try
            {
                //variables to store values from the form 
                userName = Request.Form["UserNameLogin"];
                txtbox_password = Request.Form["PasswordLogin"];

                //Calling insert method
                InsertInto.Login(userName, txtbox_password);

                //string method to get the return value
                message = InsertInto.Login(userName, txtbox_password);

                if (!message.Equals(""))
                {
                    //open the dashboard page and passing the username
                    Response.Redirect("/UserDashBoard?userName=" + userName);
                }
                else
                {
                    check = true;

                    message = "User not found please enter the correct details";
                }
            }
            //catch sql exceptions
            catch (SqlException Error)
            {
                
                message = Error.Message;
            }
            //catch any other error
            catch (Exception Error)
            {
                message = Error.Message;
            }
            


        }
    }
}
