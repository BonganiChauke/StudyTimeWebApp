using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ClassLibrary
{
    public class InsertInto
    {
        public static string users = "";
        public static string newPass = "";

        public static SqlConnection Connection = new SqlConnection(@"Server=Romeo\SQLEXPRESS;Database=StudyTimeDatabase;Trusted_Connection=True;");

        //method to insert into table user
        public static string InsertUser(string firstName, string lastName, string email, string userName, string password, string txtbox_userName)
        {
            string message = "";



            //opennig connection to database
            Connection.Open();

            //String to insert into table : USER_REGISTRATION 
            string query = "Insert into USER_REGISTRATIONS (FIRSTNAME,LASTNAME,EMAIL,USERNAME,PASSWORD) " +
                "Values (@FIRSTNAME,@LASTNAME,@EMAIL,@USERNAME,@PASSWORD)";

            //
            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                //adding into columns into table : REGISTRATIONS
                command.Parameters.AddWithValue("@FIRSTNAME", firstName);
                command.Parameters.AddWithValue("@LASTNAME", lastName);
                command.Parameters.AddWithValue("@EMAIL", email);
                command.Parameters.AddWithValue("@USERNAME", userName);
                command.Parameters.AddWithValue("@PASSWORD", ComputeHash(password));

                //command to execute query
                int rowsAffected = command.ExecuteNonQuery();

                //check if rows affected
                if (rowsAffected > 0)
                {
                    message = "Succussful Registration Welocome User";
                }
                else
                {
                    message = "";
                }

            }

            //close connection
            Connection.Close();


            return message;//return variable

        }//***********************************************[E]

        //method to hash password
        public static string ComputeHash(string password)
        {
            //string builder to append string character
            StringBuilder stringBuilder = new StringBuilder();

            //sha256 to hash password
            using (SHA256 PS_HASH = SHA256.Create())
            {

                byte[] hashBytes = PS_HASH.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x3"));

                }
            }

            return stringBuilder.ToString();
        }//***************************************[E]

        //method to login  
        public static string Login(string txtbox_userName, string txtbox_password)
        {
            string message;
            try
            {
                //opens the database connection
                Connection.Open();

                //query to select from the table
                String query = "Select USER_ID from USER_REGISTRATIONS  where USERNAME='" + txtbox_userName + "' AND PASSWORD='" + ComputeHash(txtbox_password) + "'";

                //sql command to execute the query and connection
                SqlCommand command = new SqlCommand(query, Connection);


                //sql reader to read from the table 
                SqlDataReader sqlData = command.ExecuteReader();


                //data read find matching data in the table 
                if (sqlData.Read())
                {
                    users = txtbox_userName;
                    message = "Succesful Login, Welcome User";


                }
                else
                {
                    message = "";
                }

            }
            catch (Exception Error)
            {

                message = Error.Message;

            }
            finally
            {
                //close connection
                Connection.Close();
            }

            return message;
        }//*****************************************************************[e]

        //methos to insert into table modules
        public static void InsertModules(string moduleCode, string moduleName, int numberOfCredits, int classHoursPerWeek, int numberOfWeeks, string startDate, string endDate, string userName, int selfStudy_hoursPerWeek)
        {

            //Open connection to the database
            Connection.Open();

            //string 
            string query = "INSERT INTO USER_MODULE (MODULE_CODE, MODULE_NAME, NUMBER_OF_CREDITS, CLASS_HOURS_PER_WEEK, NUMBER_OF_WEEKS, START_DATE, END_DATE, USERNAME, selfStudy_hoursPerWeek)" +
                " VALUES (@MODULE_CODE,@MODULE_NAME,@NUMBER_OF_CREDITS,@CLASS_HOURS_PER_WEEK,@NUMBER_OF_WEEKS,@START_DATE, @END_DATE, @USERNAME, @selfStudy_hoursPerWeek)";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@MODULE_CODE", moduleCode);
            command.Parameters.AddWithValue("@MODULE_NAME", moduleName);
            command.Parameters.AddWithValue("@NUMBER_OF_CREDITS", numberOfCredits);
            command.Parameters.AddWithValue("@CLASS_HOURS_PER_WEEK", classHoursPerWeek);
            command.Parameters.AddWithValue("@NUMBER_OF_WEEKS", numberOfWeeks);
            command.Parameters.AddWithValue("@START_DATE", startDate);
            command.Parameters.AddWithValue("@END_DATE", endDate);
            command.Parameters.AddWithValue("@USERNAME", userName);
            command.Parameters.AddWithValue("@selfStudy_hoursPerWeek", selfStudy_hoursPerWeek);

            command.ExecuteNonQuery();//executes query
            Connection.Close();

        }//***********************************************************************[E]

        //method to update password when user whats to reset password
        public static void resetPassword(string resetUser_newPassword, string resetUser_EmailUsername)
        {
            Connection.Open();//open connection

            //command with a query
            SqlCommand command = new SqlCommand("UPDATE USER_REGISTRATIONS SET PASSWORD='" + ComputeHash(resetUser_newPassword) + "' WHERE USERNAME= '" + resetUser_EmailUsername + "'", Connection);

            command.ExecuteNonQuery();//exexcute command with query

            Connection.Close();//close connection

        }
        //************************************[e]


        //method to calculate hours left
        public string hoursSpendCalculation(string module_Code, string spend_hours)
        {
            //query to get moduleCode
            string query_getModuleCode = "Select * from USER_MODULE where MODULE_CODE='" + module_Code + "';";

            Connection.Open();//open connection to database

            //adapter to fill the dataTable with query: query_getModuleCode
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query_getModuleCode, Connection);

           

            //datatable to get data
            DataTable table = new DataTable();

            dataAdapter.Fill(table);//fills the datatable

            //getting selfstudy hours from the table row
            string? selfStudyHours = table.Rows[0]["selfStudy_hoursPerWeek"].ToString();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            //if statement to check if selfStudyHours contains a negative number
            if (selfStudyHours.Contains("-") || selfStudyHours.Equals("No Hours Left"))
            {
                selfStudyHours = "No Hours Left";
            }
            else if (!selfStudyHours.Contains("") || !selfStudyHours.Equals(""))
            {
                //double variable if the values has a remainder and calculates
                double newSelfStudyHours = int.Parse(selfStudyHours) - int.Parse(spend_hours);

                selfStudyHours = " " + newSelfStudyHours;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            //query to update module at the moduleCode because its a unique code
            string query = "Update USER_MODULE set selfStudy_hoursPerWeek ='" + selfStudyHours + "' Where MODULE_CODE='" + module_Code + "';";

            SqlCommand command = new SqlCommand(query, Connection);// to perform query
            command.ExecuteNonQuery();//executes query

            Connection.Close();//close connection
            return selfStudyHours;// return self study hours

        }
    }
}
