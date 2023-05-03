# SoftwareEngineerTest

**Note** to access all functions from after run the project
         **https://localhost:7010/swagger/index.html**

## Database Requirements:
  - Create in a SQL database called (SoftwareEngineerTest) on your local machine.
  - Create a table called (Drivers) with columns Id,FirstName, LastName, Email, PhoneNumber.
  - Or you can run database script attached (SQLSoftwareEngineerTest.sql

## Requirements:
**Please create a basic CRUD application without the use of Entity Framework that will allow the
(Create, Read, Update, and Delete) operations to be completed on the following Driver model
o Driver: FirstName, LastName, Email, PhoneNumber**
- I have add a folder called (DatabaseCURD) has class (DriverCRUD.cs) with all database CRUD oprations.
**Create the REST API using C# to perform the above operations**
- Also added it in (Controllers) in (DriverController.cs).
**You can use a simple interface in Angular or a CLI is acceptable as well**
- you can see default interface in (https://localhost:7010/swagger/index.html).
**Please have functionality built in to insert a list of 100 random names that you create. The
names do not need to be actual names, random strings are fine**
- this Api called (InsertDriverRandom100) in controller.
**Also have functionality to display an alphabetized list of the current users in the database**
- this return all drivers names order by first name then last name called (SelectAllDriversOrdered).
**There should be functionality to return the user’s name alphabetized as well
o Example return Oliver Johnson alphabetized
o Example output: eilOrv hJnnoos**
- this api return all driver names and alphabetalized there names Called (SelectAllDriversAlphabetized).
- 
