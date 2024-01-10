using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class ModulesModel : PageModel
    {
        public void OnGet()
        {
        }
        // variables to declare textbox
        public string message = "";
        public int selfStudy_hoursPerWeek;
        //public Boolean check = false;

        public List<Modules> moduleObj = new List<Modules>();//Declaring the class module as a list
        public Modules? moduleClassList; //declaring a class object

        public void OnPost()
        {
            //try catch to handle errors
            try
            {
                //variable to store user inputs
                string moduleCode = Request.Form["MODULE_CODE"];
                string moduleName = Request.Form["MODULE_NAME"];
                int numberOfCredits = int.Parse(Request.Form["NUMBER_OF_CREDITS"]);
                int classHoursPerWeek = int.Parse(Request.Form["CLASS_HOURS_PER_WEEK"]);
                int numberOfWeeks = int.Parse(Request.Form["NUMBER_OF_WEEKS"]);
                string startDate = Request.Form["START_DATE"];
                string endDate = Request.Form["END_DATE"];
                string userName = Request.Query["userName"];

                //selfStudy_hoursPerWeek = numberOfCredits * 10 / numberOfWeeks - classHoursPerWeek;
                selfStudy_hoursPerWeek = Modules.selfHours(selfStudy_hoursPerWeek, numberOfCredits, numberOfWeeks, classHoursPerWeek);


                //method to insert into table modules
                InsertInto.InsertModules(moduleCode, moduleName, numberOfCredits, classHoursPerWeek, numberOfWeeks, startDate, endDate, userName, selfStudy_hoursPerWeek);

            }
            //to catch only sql errors
            catch (SqlException ex)
            {
                //ex.Number catches the duplicate value in the table because it's a primary key 
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    if (ex.Message.Contains("unique"))
                    {
                        message = "This module code already please enter a different module code";
                    }
                    else
                    {
                        message = "This module code already please enter a different module code";
                    }
                }
                else
                {
                    //error message 
                    message = ex.Message;
                }
            }
            catch (FormatException)
            {
                message = "Input for numbers can not contain letters or special characters";
            }
            //catches other errors
            catch (Exception Error)
            {
                message = Error.Message;
                
            }
        }
    }
}
