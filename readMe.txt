Application : Study Time

Application Background : The application is for students, learners or anyone that whats to study a particular subject or module this application 
will help them to calculate the self study hours and manage their their study time while using the application.

Applications to have 

1. C#:The programming language for application and and scripting languages html, css, and javascript.<br>
2. ASP.NET Core: Used for creating the desktop user interface.<br>
3. .NET Standard 6.0: Provides essential libraries and tools for ASP.NET Core
4. Visual Studio 2022: The integrated development environment (IDE) for C# and ASP.NET Core
5. SQL Server Management Studio Management: Used for creating database.

User Functionality
User Registration: The user is able to register their account if their first time users. They registered all their details which are saved in a database. The software shall stores the hash of the password in the database to secure the users data
User Login: The application uses a login feature whereby the user enters their username and their password in order to be able to login. If they forget their password they can recover it
Adding Modules: Users can add multiple modules for the semester, providing essential details for each module, including code, name, number of credits, and class hours per week
Semester: Users can specify the number of weeks in the semester and set a start date for the first week
Self-Study hours per week Calculation: The application calculates and displays the number of hours of self-study required for each module per week. This calculation is based on the number of credits a module has and the total number of weeks in the semester, taking into account class hours per week.</li>
Data Storage: User data is stored in memory while the software is running, ensuring privacy and data security. The application does not persist user data between runs, which means that data is only available during the current session.</li>
ASP.NET Core Web Application offers an intuitive and user-friendly interface for managing study hours and ensuring effective time management during an academic semester.

Usage :

First download Microsoft Visual Studio from https://visualstudio.microsoft.com/downloads/ for running the application and SQL Server Management Studio for database from https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
follow instruction from both website to install on personal computer please note this application will be used on Computer not a cellphone

After downloading the file ST10061533-StudyWebApp-POE unzip the folder using any appplication to unzip files on your computer like https://www.winzip.com/en/pages/download/winzip-b3/?x-target=ppc&promo=ppc&utm_source=google&utm_medium=cpc&utm_campaign=wz-dd-all-adwordsppc&utm_content=160010506971&utm_term=winzip&utm_id=20624671898&gad_source=1&gclid=CjwKCAjwv-2pBhB-EiwAtsQZFPNAxPoHQ9EpL4c6wz570izM4lnoKYJxK94x8cRPPz1q4nnO6gWpQhoCfHgQAvD_BwE
after unzip open the folder and open ST10061533-StudyWebApp-POE.sln and open with Microsoft Visual Studio and open SQL Server Management Studio and click open file and navigate to ST10061533-StudyWebApp-POE folder and drag and drop ChaukeStudyTime-Database.sql file SQL Server Management Studio on and will and click execute to run the database query

On visual studion you will need a connection string which is @"Data Source=lab000000\SQLEXPRESS;Initial Catalog=StudyTimeDatabase;Integrated Security=True"

To use the application a user must have Microsoft Visual Studio and have access to ST10061533-StudyWebApp-POE project files and click ST10061533-StudyWebApp-POE.csproj or ST10061533-StudyWebApp-POE.sln file to run the application 
On Microsoft Visual Studio under the start button on the ribbon the user will select ST10061533-StudyWebApp-POE under the drop down button or press start to execute application
To run the app a user can use this command (ctrl + f5) or press the smaller green play button. 

Upon running the application the user will will be presented with a user interface with the logo, name , a button for create account and login

Whats required to register
First Name and Last Name

For this application must register with an valid username and password

for password 
                
                Password must meet the following  password 
                requirements, the password must be:
                • At least 8 characters long 
                • Contain a capital letter 
                • Contain a number 
                • Contain a special character

for username 

Username contains an underscore and is no more than 8 characters long

upon successful registration the user will be directed to login page to login with their account upon successful login the user will be directed to The user dashboard will have a menu on the left of the screen

The menu will consits of the following buttons -
	
	Home - Consits of study tips 

	User Profile - The user can see all their details including first name, last name, email, and username.

	Add Modules - The user will be prompted to add module details - Module Code, Module Name, number of credits, class hours per week, number of weeks, start and end date for the module
			the will be a save button to save the modules when done successful a prompt indicating to the user that the module is saved while saving the module the is calculation
			that will calculate to self study hours per week based on: number of credits × 10 divide by number of weeks−class hours per week

	View Modules - The user will be able to view the list of recorded modules and each day of the week when they spend certain hours they will be able to subtract the hours used and the calculation
			will be based the self study hours per minus hours spend on that module. The user will choose the module they wish to calculate hours spend on and promted to specify the exact 
			number of hours and click calculate and the result will be shown to the user.
			To calculate the user will select module code and enter a number on the input box and click calculate after calculate scroll down you will see a pie chart and bar graph which has show the hours left to study on each modules

	Log out - The user can log out of the application.

You can reset password if forgotten on the login page by clicking reset password 
Please view changelog file to see changes on the class library
