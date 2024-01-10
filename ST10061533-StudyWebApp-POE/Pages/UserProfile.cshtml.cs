using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ST10061533_StudyWebApp_POE.Pages
{
    public class UserProfileModel : PageModel
    {
        public string? userName;
        public List<Users> userList = new List<Users>();

        public void OnGet()
        {
            userName = Request.Query["userName"];

            try
            {
                InsertInto.Connection.Open();
                SqlCommand command = new SqlCommand("SELECT FIRSTNAME, LASTNAME, EMAIL, USERNAME from USER_REGISTRATIONS where USERNAME ='" + userName + "'", InsertInto.Connection);

                //sql data reader
                SqlDataReader dataReader = command.ExecuteReader();

                int count = 0;
                while (dataReader.Read())
                {


                    Users user = new Users();
                    user.FIRSTNAME = dataReader.GetString(0);
                    user.LASTNAME = dataReader.GetString(1);
                    user.EMAIL = dataReader.GetString(2);
                    user.USERNAME = dataReader.GetString(3);
                    userList.Add(user);

                    count++;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                InsertInto.Connection.Close();
            }
        }
    }
}
