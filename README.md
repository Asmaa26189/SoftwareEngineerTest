# SoftwareEngineerTest

**Note** to access all functions from after run the project
        Example: **https://localhost:7010/swagger/index.html**

## Database Requirements:
  - Create in a SQL database called (SoftwareEngineerTest) on your local machine.
  - Create a table called (Drivers) with columns Id,FirstName, LastName, Email, PhoneNumber.
  - Or you can run database script attached (SQLSoftwareEngineerTest.sql)

## Requirements:
### Please create a basic CRUD application without the use of Entity Framework that will allow the(Create, Read, Update, and Delete) operations to be completed on the following Driver modelo Driver: FirstName, LastName, Email, PhoneNumber**
- I have add a folder called (DatabaseCURD) has class (DriverCRUD.cs) with all database CRUD oprations.
### Create the REST API using C# to perform the above operations
- Also added it in (Controllers) in (DriverController.cs).
### You can use a simple interface in Angular or a CLI is acceptable as well
- you can see default interface in Example (https://localhost:7010/swagger/index.html).
### **Please have functionality built in to insert a list of 100 random names that you create. The names do not need to be actual names, random strings are fine**
- this Api called (InsertDriverRandom100) in controller.
### **Also have functionality to display an alphabetized list of the current users in the database**
- this return all drivers names order by first name then last name called (SelectAllDriversOrdered).
### **There should be functionality to return the user’s name alphabetized as well
o Example return Oliver Johnson alphabetized
o Example output: eilOrv hJnnoos**
- this api return all driver names and alphabetalized there names Called (SelectAllDriversAlphabetized).

## Screenshot after run :
![image](https://user-images.githubusercontent.com/108579670/236068560-d395e5c8-7d9b-4033-b34b-994c1871a105.png)
**InsertDriver**
![image](https://user-images.githubusercontent.com/108579670/236068782-774c659e-8f35-46aa-aeea-f7241ba16294.png)
**UpdateDriver**
![image](https://user-images.githubusercontent.com/108579670/236070771-f2e29524-9cac-4396-8c0a-20e6fbffb880.png)
**DeleteDriver**
![image](https://user-images.githubusercontent.com/108579670/236071037-e1dc490b-f780-40cb-8e59-861bbec5eb99.png)
**InsertDriverRandom100**
![image](https://user-images.githubusercontent.com/108579670/236071263-c0e677f4-ba44-4a5d-8349-fb69247380cb.png)
**SelectAllDrivers**
![image](https://user-images.githubusercontent.com/108579670/236071418-f6fd166f-b5bc-4514-9578-e8b8cc51d674.png)
**SelectDriver**
![image](https://user-images.githubusercontent.com/108579670/236071614-e0e37fc8-52e8-4651-b044-28a90a091acf.png)
**SelectAllDriversAlphabetized**
![image](https://user-images.githubusercontent.com/108579670/236071778-9a9ee360-60ab-440f-aa73-7d402620bdd9.png)
**SelectAllDriversOrdered**
![image](https://user-images.githubusercontent.com/108579670/236071903-cf670cfc-3547-4be7-870a-445bb28928a1.png)






