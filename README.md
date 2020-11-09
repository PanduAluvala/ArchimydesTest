# ArchimydesTest
This is the ASP.NET WebApi solution for the archimydes test. The apis are written in C# . The database is SQL Server. Unit tests are written using Moq and Nunit Framework. 


The database is created in SQL Server and the database name is Archimydes

The mdf and ldf files for the database and zipped and kept in database folder


The api's are created using asp.net web api , sql server and entity framework database first 

The models are extracted from the service layer 

Unit tests for the models are written using nunit framework 

Integration tests are written using nunit and moq framework. 

The user can signup and login and create user stories

user can create the stories, retrive the stories created by him after login 

the jwt token should be passed in the header authroization 

Admin can get all the stories created by all users 

admin can edit the stories and reject the stories 

Passwords are encrypted and on user signup each user is assigned a jwt token geenrated using jwt nuget package 

the jwt token is validated on each request to update the stories by both user and admin 
