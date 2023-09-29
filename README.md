# ProductManagement

Product Management is a simple CRUD Application with uses a single controller ( 1 tier structure ) to perform CRUD tasks. The controller has the database DBContext injected to perform the database activities. 
This can be hosted on Azure App Service. 

**Setup** 

This application is using Code First approach for database using Entity Framwork . 

Run Update-Database command on Nudget CLI to add the local database.
or
Change the connection string to your azure database and update the schema

Run the project on localhost and use swagger to test each API

**API**

This is a CRUD application with following APIS
1. GETALL
2. GET
3. POST
4. PUT
5. DELETE

**Model**

Product - Id , Name
