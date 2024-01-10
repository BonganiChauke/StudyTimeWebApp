using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class ResetPasswordModel : PageModel
    {
        public void OnGet()
        {
        }
        public string message = "";

        public void OnPost()
        {
            try
            {
                string resetUser_EmailUsername = Request.Form["UserNameReset"];
                string resetUser_newPassword = Request.Form["NewPasswordReset"];
                string confirmNewPassword = Request.Form["confirmPasswordReset"];

                if (Validate.ResetPassword(resetUser_newPassword, resetUser_EmailUsername))
                {
                    Validate.checkResetPassword = true;
                    //open the dashboard page 
                    Response.Redirect("/Login");
                }
                else if (!Validate.ResetPassword(resetUser_newPassword, resetUser_EmailUsername))
                {
                    message = "Failed Password Reset";
                    Validate.checkResetPassword = false;
                }
            }
            catch (Exception Error)
            {

                message = Error.Message;
            }


        }
    }
}
