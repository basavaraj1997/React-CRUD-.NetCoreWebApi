React-CRUD-asp.NetCore Web Api Example
This is a simple and easy-to-understand example of a CRUD (Create, Read, Update, Delete) application built using React for the front-end and ASP.NET Core Web API for the back-end. Bootstrap is used for styling.

The application provides the following functionality:
i.Create a new record
ii.Update an existing record
iii.Show a list of records
iv.Delete/remove a record. Before deleting, a confirmation dialog box is shown to confirm the deletion.
****License*****
Feel free to change the code according to your needs. 
The project is released under an open-source license.

Steps to Run the Project
1.Clone the project to your local computer and unzip it.
2.Create a database named 'crud' (or any other name of your choice).
3.To create the necessary table, check the DBScript.sql file and run it on your SQL Server.
4.Replace the connection string in the appsettings.json file with your own connection string, including your SQL Server user ID and password.
5.Run the ASP.NET Core Web API project.
6.Open the react-crud project folder in VS Code.
7.Go to the package.json file and change the proxy URL to your ASP.NET Core Web API URL.
8.After changing the proxy URL, run the React project using the command npm run start.
9.If you encounter any errors, try updating your NPM version. To do this, delete the node_modules folder and run the command npm install.
