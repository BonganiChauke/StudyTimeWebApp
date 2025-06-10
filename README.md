# Study Time Web Application

A comprehensive ASP.NET Core web application designed to help students, learners, and anyone studying particular subjects or modules to calculate self-study hours and manage their study time effectively.

## 📋 Table of Contents

- [About the Application](#about-the-application)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Installation Guide](#installation-guide)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [User Guide](#user-guide)
- [Password Requirements](#password-requirements)
- [Application Navigation](#application-navigation)
- [Contributing](#contributing)
- [Author](#author)

## 🎯 About the Application

The Study Time application is specifically designed for students, learners, or anyone who wants to study particular subjects or modules. This application helps users calculate their self-study hours and manage their study time efficiently while using the application.

## ✨ Features

### Core Functionality
- **User Registration & Authentication**: Secure user registration with encrypted password storage
- **Module Management**: Add and manage multiple modules for the semester
- **Study Time Calculation**: Automatic calculation of required self-study hours per week
- **Progress Tracking**: Track hours spent on each module with visual analytics
- **Data Visualization**: Pie charts and bar graphs showing study progress
- **Password Recovery**: Reset forgotten passwords
- **User Profile Management**: View and manage personal information

### Security Features
- Password hashing for secure data storage
- Session-based data management
- Secure login system

## 🛠️ Technologies Used

- **Programming Language**: C#
- **Web Framework**: ASP.NET Core
- **Runtime**: .NET Standard 6.0
- **Frontend**: HTML5, CSS3, JavaScript
- **Database**: SQL Server
- **IDE**: Visual Studio 2022
- **Database Management**: SQL Server Management Studio

## 📋 Prerequisites

Before installing and running this application, ensure you have the following software installed:

1. **Microsoft Visual Studio 2022**
   - Download from: [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
   
2. **SQL Server Management Studio (SSMS)**
   - Download from: [SSMS Download](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

3. **File Extraction Tool** (for unzipping project files)
   - Recommended: [WinZip](https://www.winzip.com/) or any compatible extraction tool

> **Note**: This application is designed for desktop/computer use, not mobile devices.

## 🚀 Installation Guide

### Step 1: Download and Extract Project Files

1. Download the `ST10061533-StudyWebApp-POE` project file
2. Extract the folder using your preferred file extraction tool
3. Navigate to the extracted folder

### Step 2: Open Project in Visual Studio

1. Locate and open `ST10061533-StudyWebApp-POE.sln` with Microsoft Visual Studio 2022
2. Wait for the project to load completely

### Step 3: Configure Connection String

Update the connection string in your application configuration:

```csharp
@"Data Source=lab000000\SQLEXPRESS;Initial Catalog=StudyTimeDatabase;Integrated Security=True"
```

## 🗄️ Database Setup

### Setting up the Database

1. Open **SQL Server Management Studio**
2. Navigate to the project folder `ST10061533-StudyWebApp-POE`
3. Drag and drop the `ChaukeStudyTime-Database.sql` file into SSMS
4. Click **Execute** to run the database query and create the database

## ▶️ Running the Application

### Method 1: Using Visual Studio Interface
1. In Visual Studio, locate the **Start** button on the ribbon
2. Select `ST10061533-StudyWebApp-POE` from the dropdown menu
3. Click **Start** to execute the application

### Method 2: Using Keyboard Shortcut
- Press `Ctrl + F5` to run the application without debugging

### Method 3: Using Play Button
- Click the green **Play** button in Visual Studio

## 📖 User Guide

### Initial Setup

Upon launching the application, you'll see the main interface with:
- Application logo and name
- **Create Account** button
- **Login** button

### User Registration

To register a new account, provide:

**Required Information:**
- First Name
- Last Name
- Valid Username
- Secure Password

#### Username Requirements
- Must contain an underscore (_)
- Maximum 8 characters long
- Example: `user_123`

#### Password Requirements

Your password must meet ALL of the following criteria:
- ✅ At least **8 characters long**
- ✅ Contain at least **one capital letter**
- ✅ Contain at least **one number**
- ✅ Contain at least **one special character**

Example of valid password: `MyPass123!`

### Login Process

1. Enter your registered username and password
2. Click **Login**
3. Upon successful authentication, you'll be redirected to the user dashboard

### Password Recovery

If you forget your password:
1. Click **Reset Password** on the login page
2. Follow the prompts to recover your account access

## 🧭 Application Navigation

The user dashboard features a left-side menu with the following options:

### 🏠 Home
- Displays helpful study tips and recommendations

### 👤 User Profile
View your personal information including:
- First Name
- Last Name
- Email Address
- Username

### ➕ Add Modules
Add new study modules with the following details:
- **Module Code**: Unique identifier for the module
- **Module Name**: Full name of the subject/module
- **Number of Credits**: Credit value of the module
- **Class Hours per Week**: Scheduled class time
- **Number of Weeks**: Duration of the module
- **Start Date**: Module commencement date
- **End Date**: Module completion date

**Automatic Calculation**: The system automatically calculates self-study hours per week using the formula:
```
Self-Study Hours = (Number of Credits × 10 ÷ Number of Weeks) - Class Hours per Week
```

### 📊 View Modules
- View list of all recorded modules
- Track daily study hours for each module
- Calculate remaining study hours per module
- **Interactive Features**:
  - Select specific modules to track
  - Enter hours spent studying
  - Click **Calculate** to update progress
  - View **Pie Charts** and **Bar Graphs** showing study progress

### 🚪 Log Out
Securely log out of the application

## 📈 Study Progress Visualization

The application provides comprehensive analytics through:
- **Pie Charts**: Visual representation of time distribution across modules
- **Bar Graphs**: Progress tracking for individual modules
- **Real-time Calculations**: Updated study hours based on time logged

## 📋 Usage Workflow

1. **Register** your account with secure credentials
2. **Login** to access the dashboard
3. **Add Modules** with all required details
4. **Track Study Time** by logging hours spent on each module
5. **Monitor Progress** through visual analytics
6. **Adjust Study Schedule** based on remaining hours needed

## 🤝 Contributing

We welcome contributions to improve the Study Time application. Please ensure you:
1. Follow the existing code structure
2. Test your changes thoroughly
3. Update documentation as needed
4. Check the changelog file for recent updates

## 👨‍💻 Author

**Bongani Chauke**
- GitHub: [@BonganiChauke](https://github.com/BonganiChauke)

## 📝 Additional Notes

- **Data Storage**: User data is stored in memory during application runtime for privacy and security
- **Session Management**: Data is only available during the current session
- **Platform**: Designed for desktop/computer use only
- **Database**: All user information and modules are securely stored in SQL Server database

## 🔄 Updates

Please refer to the changelog file to see recent changes and updates to the class library.

---

⭐ **Start managing your study time effectively today!** ⭐
