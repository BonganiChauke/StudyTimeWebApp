using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;
using System.Data.SqlClient;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class ViewModel : PageModel
    {
        //username variable
        public string userName = "", message = "";

        //Instance of a InsertInto class object 
        InsertInto into = new InsertInto();

        //declaring a class as a list to add modules data from sql server into collection
        public List<Modules> moduleslist = new List<Modules>();

        public void OnGet()
        {
            //request the user used to log to get their data
            userName = Request.Query["userName"];

            //try catch to handle errors
            try
            {
                //Opening connection to database
                InsertInto.Connection.Open();

                //sql command to perform database query
                SqlCommand command = new SqlCommand("SELECT MODULE_ID, MODULE_CODE AS 'Module Code' , MODULE_NAME AS 'Module Name', NUMBER_OF_CREDITS AS 'Credits', CLASS_HOURS_PER_WEEK AS 'Hours Per Week', NUMBER_OF_WEEKS AS 'Number of Week', START_DATE AS 'Start Date',  END_DATE AS 'End Date', selfStudy_hoursPerWeek AS 'Study Hours Per Week' from USER_MODULE where USERNAME ='" + userName + "'", InsertInto.Connection);

                //sql data reader
                SqlDataReader dataReader = command.ExecuteReader();

                //while loop to read data into variables from the Modules class
                while (dataReader.Read())
                {
                    Modules modules = new Modules();
                    modules.MODULE_ID = dataReader.GetInt32(0);
                    modules.ModuleCode = dataReader.GetString(1);
                    modules.ModuleName = dataReader.GetString(2);
                    modules.NumberOfCreadits = dataReader.GetInt32(3);
                    modules.ClassHoursPerWeek = dataReader.GetInt32(4);
                    modules.NumberOfWeeks = dataReader.GetInt32(5);
                    modules.StartDate = dataReader.GetString(6);
                    modules.EndDate = dataReader.GetString(7);
                    modules.SelfStudyhoursPerWeek = dataReader.GetString(8);

                    //this if is to check if modules.SelfStudy_hoursPerWeek has an negative or equals zero and show the user 
                    //no hours left to study however this has no effect on the database
                    if (modules.SelfStudyhoursPerWeek.Contains("-") || int.Parse(modules.SelfStudyhoursPerWeek) == 0)
                    {
                        modules.SelfStudyhoursPerWeek = "No Hours Left";
                    }

                    //adding to the list collection
                    moduleslist.Add(modules);
                }

            }
            //handling of sql exception errors
            catch (SqlException Error)
            {
                message = Error.Message;
            }
            //handling of any other error
            catch (Exception Error)
            {
                //letting the user know the error
                message = Error.Message;

            }
            finally
            {
                //Closing connection to database
                InsertInto.Connection.Close();
            }


        }//*********************************[E]


        public void OnPost()
        {

            //try catch to handle error
            try
            {
                //requesting values from the form
                string code = Request.Form["id"];
                string HOURS_USED = Request.Form["HOURS_USED"];

                //calling the method to calculate hours spend and updating self study hours
                into.hoursSpendCalculation(code, HOURS_USED);

                //Calling onGet method after the hours spend has been updated
                OnGet();
            }
            //handling of sql exception errors
            catch (SqlException Error)
            {
                message = Error.Message;
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
            
            
        }//**********************[E]  
    }
}
